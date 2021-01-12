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
    public class MessagesController : Controller
    {
        private socialnetworkContext _context;
        public MessagesController(socialnetworkContext context) 
        {
            _context = context;
        }
        public IActionResult Conversations() 
        {
            Guid IdUser = Guid.Parse(HttpContext.User.Identity.Name);
            IEnumerable<Участник> участия = _context.Участник.Where(t => t.ID_Пользователя == IdUser).ToList();
            List<ConversationsWithLastMessage> беседы = new List<ConversationsWithLastMessage>();
            foreach (var item in участия) 
            {
                List<Пользователь> пользователи = new List<Пользователь>();
                var беседа = _context.Беседа.Include(t => t.Участники).FirstOrDefault(t => t.ID_Беседы == item.ID_беседы);
                foreach (var участник in беседа.Участники) 
                {
                    пользователи.Add(_context.Пользователь.FirstOrDefault(t => t.ID == участник.ID_Пользователя));
                }              
                var сообщение = _context.Сообщения.Where(t => t.ID_беседы == беседа.ID_Беседы).OrderBy(t => t.Дата_отправки).Last();
                беседы.Add(new ConversationsWithLastMessage 
                {
                    беседа = беседа,
                    Пользователь = пользователи,
                    сообщение = сообщение
                });
            }
            беседы = беседы.OrderByDescending(t => t.сообщение.Дата_отправки).ToList();
            return View(беседы);
        }
        public IActionResult Dialog(string id, string? typeid) 
        {
            Guid IdUser = Guid.Parse(HttpContext.User.Identity.Name);
            List<Пользователь> Пользователи = new List<Пользователь>();
            List<Сообщения> Сообщения;
            MessagessWithUsersViewModel messagessWithUsersViewModel;
            if (id == null) 
            {
                RedirectToAction("Conversations");
            }
            if (typeid != null) 
            {
                if (typeid == "friendid")
                {
                    Guid IdFriend = Guid.Parse(id);
                    Microsoft.Data.SqlClient.SqlParameter param1 = new Microsoft.Data.SqlClient.SqlParameter("@ID1", IdFriend);
                    Microsoft.Data.SqlClient.SqlParameter param2 = new Microsoft.Data.SqlClient.SqlParameter("@ID2", IdUser);
                    Беседа беседа_персональная = _context.Беседа.FromSqlRaw("EXECUTE GetPersonalConvs @ID1, @ID2", new SqlParameter[] { param1, param2 }).AsEnumerable().FirstOrDefault();
                    if (беседа_персональная == null) 
                    {
                        Пользователи.Add(_context.Пользователь.FirstOrDefault(t => t.ID == IdUser));
                        Пользователи.Add(_context.Пользователь.FirstOrDefault(t => t.ID == IdFriend));
                        Сообщения = new List<Сообщения>();
                        messagessWithUsersViewModel = new MessagessWithUsersViewModel
                        {
                            сообщения = Сообщения,
                            пользователи = Пользователи
                        };
                        return View(messagessWithUsersViewModel);
                    }
                    id = беседа_персональная.ID_Беседы.ToString();
                }
            }
            Guid Id = Guid.Parse(id);
            Беседа беседа = _context.Беседа.Include(t => t.Участники).FirstOrDefault(t => t.ID_Беседы == Id);
            Сообщения = _context.Сообщения.Include(t => t.Участник).Where(t => t.ID_беседы == Id).OrderBy(t => t.Дата_отправки).Take(100).ToList();
            bool isForCurrentUser = false;
            foreach (var item in беседа.Участники) 
            {
                Пользователи.Add(_context.Пользователь.FirstOrDefault(t => t.ID == item.ID_Пользователя));
                if (item.ID_Пользователя == IdUser)
                    isForCurrentUser = true;
            }
            messagessWithUsersViewModel = new MessagessWithUsersViewModel
            {
                сообщения = Сообщения,
                пользователи = Пользователи
            };
            if(isForCurrentUser)
                return View(messagessWithUsersViewModel);
            return RedirectToAction("Conversations");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
