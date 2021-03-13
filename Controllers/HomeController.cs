using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vkontakte.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using Vkontakte.Hubs;
using Vkontakte.Services;

namespace Vkontakte.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private socialnetworkContext _context;
        IHubContext<ChatHub> hubContext;
        ITrendsFee _trends;
        public HomeController(ILogger<HomeController> logger, socialnetworkContext context, IHubContext<ChatHub> hubContext, ITrendsFee trends)
        {
            _logger = logger;
            _context = context;
            _trends = trends;
            this.hubContext = hubContext;
        }
        public IActionResult Index(int page = 0)
        {
            int pagesize = 10;
            List<PostBlogCommentActionViewModel> postBlogCommentActionViewModels = new List<PostBlogCommentActionViewModel>();
            Guid Id = Guid.Parse(HttpContext.User.Identity.Name);
            List<Запись> записи = (from запись in _context.Запись.Include(t => t.Блог).Include(t => t.Действия).Include(t => t.Коментарии)
                                   join блог in _context.Блог on запись.ID_Блога equals блог.ID_Блога
                                   join подписчик in _context.Подписчик on блог.ID_Блога equals подписчик.ID_Блога
                                   where подписчик.ID_Пользователя == Id && запись.Удалён == 0
                                   select запись).OrderByDescending(t => t.Дата_публикации).Skip(page * pagesize).Take(pagesize).ToList();
            foreach (var post in записи) 
            {
                IEnumerable<Коментарий> коментарии = _context.Коментарий.Include(t=>t.Пользователь).Where(t => t.ID_Записи == post.ID_Записи).ToList();
                IEnumerable<Дествие> дествия = _context.Дествие.Include(t=>t.Пользователь).Where(t => t.ID_Записи == post.ID_Записи).ToList();
                IEnumerable<Данные> data = (from данные in _context.Данные
                                            join приложения in _context.Приложение on данные.ID equals приложения.ID_Data
                                            where приложения.ID_Записи == post.ID_Записи
                                            select данные).ToList();
                postBlogCommentActionViewModels.Add(new PostBlogCommentActionViewModel
                {
                    Запись = post,
                    Блог = post.Блог,
                    Коментарии = коментарии,
                    Дествия = дествия,
                    Данные = data,
                });
            }
            if (page != 0)
                return PartialView("_Post", postBlogCommentActionViewModels);
            var gtf = postBlogCommentActionViewModels[0].Запись.Текст.Split("<br>");
            return View(postBlogCommentActionViewModels);
        }
        [AllowAnonymous]
        public IActionResult GetTrends(int page = 0) 
        {
            int pagesize = 10;
            var trendPosts = _trends.GetTrends(_context);
            List<PostBlogCommentActionViewModel> postBlogCommentActionViewModels = new List<PostBlogCommentActionViewModel>();
            List<Запись> записи = (from запись in _context.Запись.Include(t => t.Блог).Include(t => t.Действия).Include(t => t.Коментарии).Where(t => t.Удалён == 0).ToList()
                                   join тренды in trendPosts on запись.ID_Записи equals тренды.ID
                                   select запись).OrderByDescending(t => t.Дата_публикации).Skip(page * pagesize).Take(pagesize).ToList();
            foreach (var post in записи)
            {
                IEnumerable<Коментарий> коментарии = _context.Коментарий.Include(t => t.Пользователь).Where(t => t.ID_Записи == post.ID_Записи).ToList();
                IEnumerable<Дествие> дествия = _context.Дествие.Include(t => t.Пользователь).Where(t => t.ID_Записи == post.ID_Записи).ToList();
                IEnumerable<Данные> data = (from данные in _context.Данные
                                            join приложения in _context.Приложение on данные.ID equals приложения.ID_Data
                                            where приложения.ID_Записи == post.ID_Записи
                                            select данные).ToList();
                postBlogCommentActionViewModels.Add(new PostBlogCommentActionViewModel
                {
                    Запись = post,
                    Блог = post.Блог,
                    Коментарии = коментарии,
                    Дествия = дествия,
                    Данные = data
                });
            }
            if(page != 0)
                return PartialView("_Post", postBlogCommentActionViewModels);
            return View("Index", postBlogCommentActionViewModels);
        }
        public IActionResult GetPostComents(string id) 
        {
            Guid IdPost = Guid.Parse(id);
            Guid IdUser = Guid.Parse(HttpContext.User.Identity.Name);
            Запись запись = _context.Запись.Include(t => t.Действия).Include(t => t.Коментарии).Include(t => t.Блог).FirstOrDefault(t => t.ID_Записи == IdPost);
            bool isLike = запись.Действия.FirstOrDefault(t => t.ID_Пользователя == IdUser && t.Код == 1) == null ? false : true;
            ViewBag.isLike = isLike;
            IEnumerable<Данные> data = (from данные in _context.Данные
                                        join приложения in _context.Приложение on данные.ID equals приложения.ID_Data
                                        where приложения.ID_Записи == запись.ID_Записи
                                        select данные).ToList();
            PostBlogCommentActionViewModel postBlogCommentActionViewModel = new PostBlogCommentActionViewModel
            {
                Запись = запись,
                Блог = запись.Блог,
                Коментарии = _context.Коментарий
                .Include(t => t.Пользователь)
                .Where(t => t.ID_Записи == запись.ID_Записи)
                .OrderByDescending(t=>t.Дата_коментария)
                .ToList(),
                Дествия = _context.Дествие.Include(t => t.Пользователь).Where(t => t.ID_Записи == запись.ID_Записи).ToList(),
                Данные = data
            };
            return PartialView("_GetComents", postBlogCommentActionViewModel);
        }
        [HttpPost]
        public IActionResult LikeAdd( string id) 
        {
            Guid Id = Guid.Parse(HttpContext.User.Identity.Name);
            var user = _context.Пользователь.FirstOrDefault(t => t.ID == Id);
            string action = "null";
            int count = -1;
            if (id != null) 
            {
                var like = _context.Дествие.Where(t => t.ID_Пользователя == user.ID && t.ID_Записи == Guid.Parse(id)).ToList().FirstOrDefault(t => t.Код == 1);
                action = "add";
                if (like != null)
                {
                    _context.Дествие.Remove(like);
                    action = "delete";
                }
                else
                {
                    Дествие дествие = new Дествие
                    {
                        ID_Записи = Guid.Parse(id),
                        ID_Пользователя = user.ID,
                        Дата_действия = DateTime.Now,
                        Код = 1
                    };
                    _context.Add(дествие);
                }
                _context.SaveChanges();
                count = _context.Дествие.Where(t => t.ID_Записи == Guid.Parse(id) && t.Код == 1).ToList().Count();
            }
            
            return Content(action + ";" + count.ToString());
        }
        public IActionResult ViewAdd(string id) 
        {
            Guid user_id = Guid.Parse(HttpContext.User.Identity.Name);
            Guid post_id = Guid.Parse(id);
            Дествие просмотр = _context.Дествие.Where(t => t.ID_Пользователя == user_id && t.ID_Записи == post_id).ToList().FirstOrDefault(t => t.Код == 2);
            int count = -1;
            if (просмотр == null) 
            {
                var id_user_param = new Microsoft.Data.SqlClient.SqlParameter("@id_user", user_id);
                var id_post_param = new Microsoft.Data.SqlClient.SqlParameter("@id_post", post_id);
                _context.Database.ExecuteSqlRaw("AddView @id_user, @id_post", new Microsoft.Data.SqlClient.SqlParameter[] { id_user_param, id_post_param });
                _context.SaveChanges();
                    
            }
            count = _context.Дествие.Where(t => t.ID_Записи == post_id && t.Код == 2).ToList().Count();
            return Json(new
            {
                count = count
            });
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckEmail(string email)
        {
            if (email == "admin@mail.ru" || email == "aaa@gmail.com")
                return Json(false);
            return Json(false);
        }
    }
}
