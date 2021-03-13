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
using Vkontakte.Services;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace Vkontakte.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private socialnetworkContext _context;
        private IFriendFee _friendFee;
        public UsersController(socialnetworkContext context, IFriendFee friendsFee) 
        {
            _context = context;
            _friendFee = friendsFee;
        }
        public IActionResult AdvancedSearch(string? sortstate, string? country, string? city, string? pattern, int page = 0, int repeat = 0) 
        {
            int pagesize = 20;
            Guid IdUser = Guid.Parse(HttpContext.User.Identity.Name);
            if (pattern == null)
                pattern = "%";
            else
                pattern = pattern + "%";
            if (city == null)
                city = "%";
            else
                city = city + "%";
            if (country == null)
                country = "%";
            else
                country = country + "%";
            var Users = _friendFee.GetUsersWithCommon(IdUser, _context, page * pagesize, pagesize, pattern, city, country);
            switch (sortstate) 
            {
                case "Default":
                    break;
                case "Abc":
                    Users = Users.OrderBy(t => t.Фамилия).ToList();
                    break;
                case "Cba":
                    Users = Users.OrderByDescending(t => t.Фамилия).ToList();
                    break;
                default:
                    break;
            }
            List<UserFriendBlogViewModel> users = new List<UserFriendBlogViewModel>();
            foreach (var user in Users) 
            {
                users.Add(new UserFriendBlogViewModel()
                {
                    пользователь = _context.Пользователь.FirstOrDefault(t => t.ID == user.ID),
                    Аватарка = _context.Аватарка.Include(t => t.Данные).FirstOrDefault(t => t.ID_Пользователя == user.ID),
                    CountBlogs = 0,
                    дружбы = null,
                    CountFollowers = 0,
                    записи_пользователя = null
                });
            }
            if (repeat != 0)
                return PartialView("_Users", users);
            return View(users);
        }
        public IActionResult FindUsers(int page = 0) 
        {
            int pagesize = 33;
            Guid IdUser = Guid.Parse(HttpContext.User.Identity.Name);
            var Users = _friendFee.GetUsersWithCommon(IdUser, _context, page * pagesize, pagesize, "%", "%", "%");
            if (page != 0)
                return PartialView("_FriendsTable", Users);
            return View(Users);
        }
        public IActionResult FindByName(string? pattern) 
        {
            Guid IdUser = Guid.Parse(HttpContext.User.Identity.Name);
            IEnumerable<Пользователь> пользователи = _context.Пользователь.Where(t => EF.Functions.Like(t.Фамилия, pattern + "%") || EF.Functions.Like(t.Имя, pattern + "%")).ToList();
            пользователи = пользователи.Where(t => t.ID != IdUser).ToList();
            List<UserFriendBlogViewModel> users = new List<UserFriendBlogViewModel>();
            foreach (var user in пользователи) 
            {
                Аватарка аватарка = _context.Аватарка.Include(t => t.Данные).FirstOrDefault(t => t.ID_Пользователя == user.ID && t.Используется == true);
                users.Add(new UserFriendBlogViewModel()
                {
                    CountBlogs = 0,
                    Аватарка = аватарка,
                    дружбы = null,
                    CountFollowers = 0,
                    пользователь = user,
                    записи_пользователя = null
                });
            }
            return View(users);
        }
        [AllowAnonymous]
        public IActionResult GetUserInfo(string? id) 
        {
            Пользователь пользователь;
            if (id == null)
                id = HttpContext.User.Identity.Name;
            пользователь = _context.Пользователь.FirstOrDefault(t => t.ID == Guid.Parse(id));
            Microsoft.Data.SqlClient.SqlParameter param = new Microsoft.Data.SqlClient.SqlParameter("@FriendID", пользователь.ID);
            IEnumerable<Дружба> Friends = _context.Дружба.FromSqlRaw("EXEC GetFriends @FriendID", param).ToList().ToList();
            int CountFollowers = _context.Дружба.FromSqlRaw("EXEC GetFriends @FriendID", param).ToList().Where(t => t.Код_статуса == 1).Count();
            int BlogsCount = (from блог in _context.Блог
                              join подписчик in _context.Подписчик on блог.ID_Блога equals подписчик.ID_Блога
                              where подписчик.ID_Пользователя == пользователь.ID
                              select new { id = блог.ID_Блога }).ToList().Count();
            Аватарка аватарка = _context.Аватарка.Include(t => t.Данные).FirstOrDefault(t => t.ID_Пользователя == Guid.Parse(id) && t.Используется == true);
            List<Запись> записи = _context.Запись.Include(t => t.Блог).Include(t => t.Коментарии).Include(t => t.Действия).Include(t=>t.Приложения)
                .Where(t => t.Блог.Код_типа == 4 && t.Блог.Код_типа_тематики == 15 && t.Блог.ID_Создателя == Guid.Parse(id) && t.Удалён == 0)
                .OrderByDescending(t=>t.Дата_публикации).ToList();
            List<PostBlogCommentActionViewModel> posts = new List<PostBlogCommentActionViewModel>();
            List<Данные> все_данные = (from данные in _context.Данные
                                       join приложение in _context.Приложение
                                       on данные.ID equals приложение.ID_Data
                                       join запись in _context.Запись
                                       on приложение.ID_Записи equals запись.ID_Записи
                                       join блог in _context.Блог
                                       on запись.ID_Блога equals блог.ID_Блога
                                       where блог.ID_Создателя == Guid.Parse(id) && блог.Код_типа == 4
                                       select данные).ToList();
            foreach (var item in записи) 
            {
                List<Дествие> дествия = _context.Дествие.Include(t => t.Пользователь).Where(t => t.ID_Записи == item.ID_Записи).ToList();
                List<Данные> данные = (from данное in все_данные
                                       join приложение in item.Приложения
                                       on данное.ID equals приложение.ID_Data
                                       select данное).ToList();
                posts.Add(new PostBlogCommentActionViewModel()
                {
                    Блог = item.Блог,
                    Дествия = дествия,
                    Запись = item,
                    Коментарии = item.Коментарии,
                    Данные = данные
                });
            }
            Guid id_personal_blog = _context.Блог.First(t => t.ID_Создателя == пользователь.ID && t.Код_типа == 4).ID_Блога;
            UserFriendBlogViewModel userFriendBlogViewModel = new UserFriendBlogViewModel
            {
                пользователь = пользователь,
                CountBlogs = BlogsCount,
                CountFollowers = CountFollowers,
                дружбы = Friends,
                Аватарка = аватарка,
                записи_пользователя = posts,
                Id_personal_Blog = id_personal_blog
            };
            return View(userFriendBlogViewModel);
        }
        [HttpPost]
        public IActionResult EditAvatarForm() 
        {
            return PartialView("_EditAvatar");
        }
        [HttpPost]
        public IActionResult EditAvatar(AvatarViewModel files) 
        {
            Пользователь пользователь = _context.Пользователь.FirstOrDefault(t => t.ID == files.ID_Пользователя);
            Guid Data_ID = Guid.NewGuid();
            byte[] avatarData = null;
            using (var binaryReader = new BinaryReader(files.Avatar.OpenReadStream())) 
            {
                avatarData = binaryReader.ReadBytes((int)files.Avatar.Length);
            }
            List<Аватарка> аватарки = _context.Аватарка.Where(t => t.ID_Пользователя == пользователь.ID).ToList();
            foreach (var ава in аватарки) 
            {
                ава.Используется = false;
            }
            Данные данные = new Данные() 
            {
                ID = Data_ID,
                Data = avatarData,
            };
            Аватарка аватарка = new Аватарка()
            {
                ID_Пользователя = пользователь.ID,
                Используется = true,
                Дата_изменения = DateTime.Now,
                ID_Data = Data_ID,
                Данные = данные,
                Пользователь = пользователь,
            };
            _context.Данные.Add(данные);
            _context.Аватарка.Add(аватарка);
            _context.SaveChanges();
            return RedirectToAction("GetUserInfo");
        }
        public IActionResult EditInfo(string? id) 
        {
            if (id != null && id == HttpContext.User.Identity.Name) 
            {
                Пользователь пользователь = _context.Пользователь.FirstOrDefault(t => t.ID == Guid.Parse(id));
                if (пользователь != null)
                    return View(пользователь);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult EditInfo(Пользователь пользователь) 
        {
            _context.Пользователь.Update(пользователь);
            _context.SaveChanges();
            return RedirectToAction("GetUserInfo", "Users");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
