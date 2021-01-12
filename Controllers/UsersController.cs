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
        public IActionResult FindUsers(int page = 0) 
        {
            int pagesize = 33;
            Guid IdUser = Guid.Parse(HttpContext.User.Identity.Name);
            var Users = _friendFee.GetUsersWithCommon(IdUser, _context, page * pagesize, pagesize);
            if (page != 0)
                return PartialView("_FriendsTable", Users);
            return View(Users);
        }
        public IActionResult FindByName(string? pattern) 
        {
            Guid IdUser = Guid.Parse(HttpContext.User.Identity.Name);
            IEnumerable<Пользователь> пользователи = _context.Пользователь.Where(t => EF.Functions.Like(t.Фамилия, pattern + "%") || EF.Functions.Like(t.Имя, pattern + "%")).ToList();
            пользователи = пользователи.Where(t => t.ID != IdUser).ToList();
            return View(пользователи);
        }
        public IActionResult GetUserInfo(string? id) 
        {
            Пользователь пользователь;
            if (id == null)
                id = HttpContext.User.Identity.Name;
            пользователь = _context.Пользователь.FirstOrDefault(t => t.ID == Guid.Parse(id));
            Microsoft.Data.SqlClient.SqlParameter param = new Microsoft.Data.SqlClient.SqlParameter("@FriendID", пользователь.ID);
            IEnumerable<Дружба> Friends = _context.Дружба.FromSqlRaw("EXEC GetFriends @FriendID", param).ToList().Where(t => t.Код_статуса == 2);
            int CountFollowers = _context.Дружба.FromSqlRaw("EXEC GetFriends @FriendID", param).ToList().Where(t => t.Код_статуса == 1).Count();
            int BlogsCount = (from блог in _context.Блог
                              join подписчик in _context.Подписчик on блог.ID_Блога equals подписчик.ID_Блога
                              where подписчик.ID_Пользователя == пользователь.ID
                              select new { id = блог.ID_Блога }).ToList().Count();
            Аватарка аватарка = _context.Аватарка.Include(t => t.Данные).FirstOrDefault(t => t.ID_Пользователя == Guid.Parse(id) && t.Используется == true);
            UserFriendBlogViewModel userFriendBlogViewModel = new UserFriendBlogViewModel
            {
                пользователь = пользователь,
                CountBlogs = BlogsCount,
                CountFollowers = CountFollowers,
                дружбы = Friends,
                Аватарка = аватарка
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
