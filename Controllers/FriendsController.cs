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
    public class FriendsController : Controller
    {
        private socialnetworkContext _context;
        public FriendsController(socialnetworkContext context) 
        {
            _context = context;
        }
        public IActionResult Index(string? id)
        {
            IEnumerable<Дружба> друзья;
            if (id == null)
            {
                Guid Id = Guid.Parse(HttpContext.User.Identity.Name);
                ViewData["id"] = Id;
                Microsoft.Data.SqlClient.SqlParameter param = new Microsoft.Data.SqlClient.SqlParameter("@FriendID", Id);
                друзья = _context.Дружба.FromSqlRaw("EXEC GetFriends @FriendID", param).ToList();
                друзья = друзья.Where(t => t.Код_статуса == 2).ToList();
            }
            else 
            {
                ViewData["id"] = id;
                Microsoft.Data.SqlClient.SqlParameter param = new Microsoft.Data.SqlClient.SqlParameter("@FriendID", Guid.Parse(id));
                друзья = _context.Дружба.FromSqlRaw("EXEC GetFriends @FriendID", param).ToList();
                друзья = друзья.Where(t => t.Код_статуса == 2).ToList();
            }
            List<UserFriendBlogViewModel> users = new List<UserFriendBlogViewModel>();
            foreach (var друг in друзья) 
            {
                Аватарка аватарка = _context.Аватарка.Include(t => t.Данные).FirstOrDefault(t => t.ID_Пользователя == друг.ID_Друга);
                users.Add(new UserFriendBlogViewModel()
                {
                    Аватарка = аватарка,
                    CountBlogs = 0,
                    CountFollowers = 0,
                    дружбы = null,
                    пользователь = _context.Пользователь.FirstOrDefault(t => t.ID == друг.ID_Друга),
                });
            }                
            return View(users);
        }
        public IActionResult FindByName(string? id, string? pattern) 
        {
            IEnumerable<Дружба> друзья;
            if (id == null)
            {
                Guid Id = Guid.Parse(HttpContext.User.Identity.Name);
                ViewData["id"] = Id;
                Microsoft.Data.SqlClient.SqlParameter param = new Microsoft.Data.SqlClient.SqlParameter("@FriendID", Id);
                друзья = _context.Дружба.FromSqlRaw("EXEC GetFriends @FriendID", param).ToList().Where(t => t.Код_статуса == 2).ToList();
            }
            else
            {
                ViewData["id"] = id;
                Microsoft.Data.SqlClient.SqlParameter param = new Microsoft.Data.SqlClient.SqlParameter("@FriendID", Guid.Parse(id));
                друзья = _context.Дружба.FromSqlRaw("EXEC GetFriends @FriendID", param).ToList().Where(t => t.Код_статуса == 2).ToList();
            }
            List<UserFriendBlogViewModel> users = new List<UserFriendBlogViewModel>();
            foreach (var друг in друзья)
            {
                Пользователь пользователь = _context.Пользователь.FirstOrDefault(t => t.ID == друг.ID_Друга && EF.Functions.Like(t.Фамилия, pattern + "%"));
                if (пользователь != null) 
                {
                    users.Add(new UserFriendBlogViewModel()
                    {
                        пользователь = пользователь,
                        Аватарка = _context.Аватарка.Include(t => t.Данные).FirstOrDefault(t => t.ID_Пользователя == пользователь.ID),
                        CountBlogs = 0,
                        CountFollowers = 0,
                        дружбы = null
                    });
                }
            }
            return PartialView("_Friends", users);
        }
        public IActionResult Requests(string? type) 
        {
            IEnumerable<Дружба> друзья;
            Guid Id = Guid.Parse(HttpContext.User.Identity.Name);
            ViewData["id"] = Id;
            Microsoft.Data.SqlClient.SqlParameter param = new Microsoft.Data.SqlClient.SqlParameter("@FriendID", Id);
            if (type == "inner" || type == null)
            {
                друзья = _context.Дружба.FromSqlRaw("EXEC GetFriends @FriendID", param).ToList().Where(t => t.Код_статуса == 5).ToList();
                ViewData["type"] = "inner";
            }
            else 
            {
                друзья = _context.Дружба.FromSqlRaw("EXEC GetFriends @FriendID", param).ToList().Where(t => t.Код_статуса == 1).ToList();
                ViewData["type"] = "outer";
            }
            друзья = (from другинфо in _context.Дружба.Include(t => t.Друг).ToList()
                      join друг in друзья.ToList() on другинфо.ID_Друга equals друг.ID_Друга
                      where друг.Дата_изиенения_статуса == другинфо.Дата_изиенения_статуса && друг.ID_Пользователя == другинфо.ID_Пользователя
                      select другинфо).ToList();
            List<UserFriendBlogViewModel> users = new List<UserFriendBlogViewModel>();
            foreach (var friend in друзья) 
            {
                users.Add(new UserFriendBlogViewModel()
                {
                    пользователь = _context.Пользователь.FirstOrDefault(t => t.ID == friend.ID_Друга),
                    Аватарка = _context.Аватарка.Include(t=>t.Данные).FirstOrDefault(t => t.ID_Пользователя == friend.ID_Друга),
                    CountBlogs = 0,
                    дружбы = null,
                    CountFollowers = 0,
                });
            }
            return View(users);
        }
        public IActionResult AddToFriends() 
        {
            return Content("Hello");
        }
    }
}
