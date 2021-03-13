using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using Vkontakte.Models;
using Microsoft.AspNetCore.Authorization;

namespace Vkontakte.Controllers
{
    [Authorize]
    public class BlogsController : Controller
    {
        private socialnetworkContext _context;
        public BlogsController(socialnetworkContext context)
        {
            _context = context;
        }
        public IActionResult PublicsList()
        {
            Guid IdUser = Guid.Parse(HttpContext.User.Identity.Name);
            IEnumerable<Блог> блоги = from блог in _context.Блог.Include(t => t.Подписчики).Include(t => t.Тематика)
                                      join подписчик in _context.Подписчик on блог.ID_Блога equals подписчик.ID_Блога
                                      where подписчик.ID_Пользователя == IdUser && блог.Код_типа != 4
                                      select блог;
            блоги = блоги.ToList();
            ViewData["id"] = IdUser.ToString();
            return View(блоги);
        }
        public JsonResult FindByName(string? pattern, string? id)
        {
            Guid IdUser = Guid.Parse(HttpContext.User.Identity.Name);
            var блоги = from блог in _context.Блог.Include(t => t.Подписчики).Include(t => t.Тематика)
                        join подписчик in _context.Подписчик on блог.ID_Блога equals подписчик.ID_Блога
                        where подписчик.ID_Пользователя == IdUser && EF.Functions.Like(блог.Название, pattern + "%") && блог.Код_типа != 4
                        select new
                        {
                            ID = блог.ID_Блога,
                            ID_Создателя = блог.ID_Создателя,
                            Название = блог.Название,
                            Подписчики = блог.Подписчики.Count(),
                            Тематика = блог.Тематика.Наименование
                        };
            ViewData["id"] = IdUser.ToString();
            JsonResult jsonBlogs = Json(блоги.ToList());
            return jsonBlogs;
        }
        public JsonResult FilterBlogsByName(string? pattern)
        {
            Guid IdUser = Guid.Parse(HttpContext.User.Identity.Name);
            var блоги_пользователя = (from блог in _context.Блог.Include(t => t.Подписчики).Include(t => t.Тематика)
                                      join подписчик in _context.Подписчик on блог.ID_Блога equals подписчик.ID_Блога
                                      where подписчик.ID_Пользователя == IdUser && блог.Код_типа != 4
                                      select блог).ToList();
            var блоги = (from блог in _context.Блог.Include(t => t.Подписчики).Include(t => t.Тематика)
                         where EF.Functions.Like(блог.Название, pattern + "%") && блог.Код_типа != 4
                         select блог).ToList().Except(блоги_пользователя);
            JsonResult jsonBlogs = Json(
                (from блог in блоги
                 select new
                 {
                     id_создателя = блог.ID_Создателя,
                     id = блог.ID_Блога,
                     блог = блог.Название,
                     подписчики = блог.Подписчики.Count(),
                     тематика = блог.Тематика.Наименование
                 }).Take(100).ToList()
                ); ;
            return jsonBlogs;
        }
        [AllowAnonymous]
        public IActionResult BlogPosts(string? id, int page = 0)
        {
            int pagesize = 4;
            List<PostBlogCommentActionViewModel> postBlogCommentActionViewModels = new List<PostBlogCommentActionViewModel>();
            Guid Id = Guid.Parse(id);
            Блог blog = _context.Блог.Include(t => t.Подписчики).FirstOrDefault(t => t.ID_Блога == Id);
            IEnumerable<Запись> Записи = _context.Запись.Where(t => t.ID_Блога == blog.ID_Блога && t.Удалён == 0).OrderByDescending(t => t.Дата_публикации).Skip(page * pagesize).Take(pagesize).ToList();
            foreach (var post in Записи)
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
                    Блог = blog,
                    Коментарии = коментарии,
                    Дествия = дествия,
                    Данные = data,
                });
            }
            if (Записи.Count() == 0)
            {
                postBlogCommentActionViewModels.Add(new PostBlogCommentActionViewModel
                {
                    Запись = null,
                    Блог = blog,
                    Коментарии = null,
                    Дествия = null,
                });
            }
            if (page != 0) 
            {
                return PartialView("_Posts", postBlogCommentActionViewModels);
            }
            return View(postBlogCommentActionViewModels);
        }
        public IActionResult FindCommunity(int page = 0)
        {
            var Topics = _context.Тематика.Where(t=>t.Код_типа_тематики!=15).Select(t => t.Наименование).ToList();
            ViewBag.Topics = Topics;
            int pagesize = 10;
            Guid IdUser = Guid.Parse(HttpContext.User.Identity.Name);
            SqlParameter param1 = new SqlParameter("@ID", IdUser);
            IEnumerable<Блог> блоги = _context.Блог.FromSqlRaw("EXECUTE SearchBlogs @ID", param1).ToList();
            блоги = from блог in блоги
                    join другойблог in _context.Блог.Include(t => t.Подписчики).Include(t => t.Тематика).ToList()
                    on блог.ID_Блога equals другойблог.ID_Блога
                    where блог.Код_типа != 4
                    select другойблог;
            блоги = блоги.Skip(page * pagesize).Take(pagesize).ToList();
            return View(блоги);
        }
        public IActionResult CreateSociety() 
        {
            TopicsTypesViewModel topicsTypesViewModel = new TopicsTypesViewModel
            {
                тематики = _context.Тематика.Where(t=>t.Код_типа_тематики != 4).ToList(),
                типы = _context.ТипыБлогов.Where(t=>t.Код_типа_блога!=15).ToList()
            };
            return View(topicsTypesViewModel);
        }
        [HttpPost]
        public IActionResult CreateSociety(Блог блог) 
        {
            Guid IdUser = Guid.Parse(HttpContext.User.Identity.Name);
            блог.ID_Создателя = IdUser;
            блог.ID_Блога = Guid.NewGuid();
            блог.Дата_создания = DateTime.Now;
            Подписчик подписчик = new Подписчик
            {
                ID_Блога = блог.ID_Блога,
                ID_Пользователя = блог.ID_Создателя,
            };
            _context.Блог.Add(блог);
            _context.Подписчик.Add(подписчик);
            _context.SaveChanges();
            return RedirectToAction("PublicsList", "Blogs");
        }
        public JsonResult FilterPaginateOrderCommunityJson(string? sortState, string? pattern, string? topic, int page = 0)
        {
            var Topics = _context.Тематика.Where(t=>t.Код_типа_тематики!=15).Select(t => t.Наименование).ToList();
            ViewBag.Topics = Topics;
            int pagesize = 10;
            Guid IdUser = Guid.Parse(HttpContext.User.Identity.Name);
            SqlParameter param1 = new SqlParameter("@ID", IdUser);
            List<Блог> блоги = _context.Блог.FromSqlRaw("EXECUTE SearchBlogs @ID", param1).ToList();
            if (pattern != "" && pattern != null)
            {
                блоги = (from блог in блоги
                         join другойблог in _context.Блог.Include(t => t.Подписчики).Include(t => t.Тематика).Where(t => EF.Functions.Like(t.Название, pattern + "%")).ToList()
                         on блог.ID_Блога equals другойблог.ID_Блога
                         where блог.Код_типа != 4
                         select другойблог).ToList();
            }
            else 
            {
                блоги = (from блог in блоги
                         join другойблог in _context.Блог.Include(t => t.Подписчики).Include(t => t.Тематика).ToList()
                         on блог.ID_Блога equals другойблог.ID_Блога
                         where блог.Код_типа != 4
                         select другойблог).ToList();
            }
            if (topic != "" && topic != null)  
            {
                блоги = (from блог in блоги
                         where блог.Тематика.Наименование == topic
                         select блог).ToList();
            }
            switch (sortState) 
            {
                case "Default":
                    break;
                case "FollowersAsc":
                    блоги = блоги.OrderBy(t => t.Подписчики.Count()).ToList();
                    break;
                case "FollowersDesc":
                    блоги = блоги.OrderByDescending(t => t.Подписчики.Count()).ToList();
                    break;
                default:
                    break;
            }
            блоги = блоги.Skip(page * pagesize).Take(pagesize).ToList();
            var JsonResult = from блог in блоги
                             select new
                             {
                                 id = блог.ID_Блога,
                                 блог = блог.Название,
                                 подписчики = блог.Подписчики.Count(),
                                 тематика = блог.Тематика.Наименование
                             };
            return Json(JsonResult.ToList());
        }
        public JsonResult Subscribe(string? id) 
        {
            Guid IdUser = Guid.Parse(HttpContext.User.Identity.Name);
            Guid IdBlog = Guid.Parse(id);
            Подписчик подписчик = _context.Подписчик.FirstOrDefault(t => t.ID_Пользователя == IdUser && t.ID_Блога == IdBlog);
            string subscription = "subscribe";
            if (подписчик == null)
            {
                подписчик = new Подписчик
                {
                    ID_Блога = IdBlog,
                    ID_Пользователя = IdUser,
                };
                _context.Add(подписчик);
            }
            else 
            {
                _context.Remove(подписчик);
                subscription = "unsubscribe";
            }
            _context.SaveChanges();
            return Json(new { action = subscription });
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
