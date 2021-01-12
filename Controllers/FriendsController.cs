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
            List<Пользователь> пользователи_друзья = new List<Пользователь>();
            foreach (var друг in друзья)
                пользователи_друзья.Add(_context.Пользователь.FirstOrDefault(t => t.ID == друг.ID_Друга));
            return View(пользователи_друзья);
        }
        public JsonResult FindByName(string? id, string? pattern) 
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
            List<Пользователь> пользователи_друзья = new List<Пользователь>();
            foreach (var друг in друзья)
                пользователи_друзья.Add(_context.Пользователь.FirstOrDefault(t => t.ID == друг.ID_Друга && EF.Functions.Like(t.Фамилия, pattern + "%")));
            пользователи_друзья = пользователи_друзья.Where(t => t != null).ToList();
            for (int i = 0; i < пользователи_друзья.Count(); i++) 
            {
                пользователи_друзья[i].ИменияДружб = null;
                пользователи_друзья[i]._token = null;
                пользователи_друзья[i].Пароль = null;
                пользователи_друзья[i].Никнейм = null;
            }                
            var json = Json(пользователи_друзья);
            return json;
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
            return View(друзья);
        }
        public IActionResult AddToFriends() 
        {
            return Content("Hello");
        }
    }
}
