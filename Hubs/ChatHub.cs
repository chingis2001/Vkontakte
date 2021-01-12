using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Vkontakte.Models;

namespace Vkontakte.Hubs
{
    public class ChatHub : Hub
    {
        private socialnetworkContext _context;
        public ChatHub(socialnetworkContext context) 
        {
            _context = context;
        }
        public async Task Send(string message) 
        {
            await this.Clients.All.SendAsync("Send", message);
        }
        [HttpPost]
        public async Task Create(string? text, string? BlogId, IList<string> files)
        {
            var attachments = new List<byte[]>();
            foreach (var data in files) 
            {
                var suka = data.Substring(23);
                attachments.Add(Convert.FromBase64String(data.Substring(23)));
            }
            var UserName = Context.User.Identity.Name;
            Блог блог = _context.Блог.Find(Guid.Parse(BlogId));
            List<string> подписчики = _context.Подписчик.Where(t => t.ID_Блога == блог.ID_Блога).Select(t => t.ID_Пользователя.ToString().ToLower()).ToList();
            Запись запись = new Запись
            {
                ID_Записи = Guid.NewGuid(),
                ID_Блога = Guid.Parse(BlogId),
                Дата_публикации = DateTime.Now,
                Название = null,
                Текст = text
            };
            _context.Add(запись);
            foreach (var file in attachments) 
            {
                Guid ID_Data = Guid.NewGuid();
                Данные данные = new Данные()
                {
                    Data = file,
                    ID = ID_Data
                };
                Приложение приложение = new Приложение()
                {
                    ID_Data = ID_Data,
                    ID_Записи = запись.ID_Записи,
                    Данные = данные,
                    Запись = запись
                };
                _context.Add(данные);
                _context.Add(приложение);
            }
            _context.SaveChanges();
            foreach (var item in подписчики) 
            {
                await Clients.User(item).SendAsync("Publicated", new
                {
                    id_блога = блог.ID_Блога,
                    id_записи = запись.ID_Записи,
                    блог = блог.Название,
                    запись = запись.Название,
                    лайки = 0,
                    коментарии = 0,
                    дата_публикации = запись.Дата_публикации.ToLocalTime(),
                    текст = запись.Текст
                });
            }
        }
        public async Task SendFriendRequest(string? idFriend)
        {
            var UserName = Context.User.Identity.Name;
            Дружба дружба = new Дружба
            {
                ID_Друга = Guid.Parse(idFriend),
                ID_Пользователя = Guid.Parse(UserName),
                Дата_изиенения_статуса = DateTime.Now,
                Код_статуса = 1
            };
            Дружба дружба1 = new Дружба
            {
                ID_Друга = Guid.Parse(UserName),
                ID_Пользователя = Guid.Parse(idFriend),
                Дата_изиенения_статуса = DateTime.Now,
                Код_статуса = 5
            };
            Пользователь пользователь = _context.Пользователь.Find(Guid.Parse(UserName));
            _context.Add(дружба);
            _context.Add(дружба1);
            _context.SaveChanges();
            await Clients.User(UserName.ToLower()).SendAsync("FriendRequest", "Sended");
            await Clients.User(idFriend.ToLower()).SendAsync("FriendRequest", new
            {
                id = UserName.ToLower(),
                firstname = пользователь.Имя,
                secondname = пользователь.Фамилия,
                city = пользователь.Город,
                type = "Recived",
            });
        }
        public async Task AddToFriends(string? idFriend) 
        {
            var UserName = Context.User.Identity.Name;
            Дружба дружба = new Дружба
            {
                ID_Друга = Guid.Parse(idFriend),
                ID_Пользователя = Guid.Parse(UserName),
                Дата_изиенения_статуса = DateTime.Now,
                Код_статуса = 2
            };
            Дружба дружба1 = new Дружба
            {
                ID_Друга = Guid.Parse(UserName),
                ID_Пользователя = Guid.Parse(idFriend),
                Дата_изиенения_статуса = DateTime.Now,
                Код_статуса = 2
            };
            _context.Add(дружба);
            _context.Add(дружба1);
            _context.SaveChanges();
            Пользователь пользователь = _context.Пользователь.Find(Guid.Parse(UserName));
            await Clients.User(UserName.ToLower()).SendAsync("FriendAdded", "Accepted");
            await Clients.User(idFriend.ToLower()).SendAsync("FriendAdded", new
            {
                id = UserName.ToLower(),
                firstname = пользователь.Имя,
                secondname = пользователь.Фамилия,
                city = пользователь.Город,
                type = "Accepted",
            });
        }
        public async Task SendMessage(string? id, string? text = "", string? friendid = "") 
        {
            var UserName = Context.User.Identity.Name;
            if (id == "")
            {

                Беседа беседа = new Беседа
                {
                    ID_Беседы = Guid.NewGuid(),
                    Дата_создания = DateTime.Now,
                    Название_беседы = "personal",
                    Описание_беседы = null,
                };
                Участник участник = new Участник
                {
                    ID_беседы = беседа.ID_Беседы,
                    Дата_добавления = DateTime.Now,
                    Дата_последнего_просмотра = DateTime.Now,
                    ID_Пользователя = Guid.Parse(UserName),
                };
                Участник участник2 = new Участник
                {
                    ID_беседы = беседа.ID_Беседы,
                    Дата_добавления = DateTime.Now,
                    Дата_последнего_просмотра = DateTime.Now,
                    ID_Пользователя = Guid.Parse(friendid),
                };
                _context.Add(беседа);
                _context.Add(участник);
                _context.Add(участник2);
                List<Участник> участникs = new List<Участник>();
                участникs.Add(участник);
                участникs.Add(участник2);
                Сообщения сообщениеновое = new Сообщения
                {
                    ID_беседы = беседа.ID_Беседы,
                    ID_Пользователя = Guid.Parse(UserName.ToLower()),
                    Дата_отправки = DateTime.Now,
                    Текст_сообщения = text
                };
                _context.Add(сообщениеновое);
                Пользователь пользовательновый = _context.Пользователь.FirstOrDefault(t => t.ID == Guid.Parse(UserName));
                _context.SaveChanges();
                foreach (var item in участникs)
                {
                    var covertantId = участникs.FirstOrDefault(t => t.ID_Пользователя != item.ID_Пользователя).ID_Пользователя;
                    var covertant = _context.Пользователь.FirstOrDefault(t => t.ID == covertantId);
                    try
                    {
                        await Clients.User(item.ID_Пользователя.ToString().ToLower()).SendAsync("MessageSend", new
                        {
                            user_send = сообщениеновое.ID_Пользователя,
                            conv_id = сообщениеновое.ID_беседы,
                            conv_name = covertant.Фамилия + " " + covertant.Имя,
                            conv_user_id = covertant.ID,
                            date = сообщениеновое.Дата_отправки.Hour + " " + сообщениеновое.Дата_отправки.Minute,
                            text = сообщениеновое.Текст_сообщения,
                            firstname = пользовательновый.Имя,
                            secondname = пользовательновый.Фамилия
                        });
                    }
                    catch (Exception ex) 
                    {
                        var a = 1;
                    }
                }
            }
            else 
            {
                Сообщения сообщение = new Сообщения
                {
                    ID_беседы = Guid.Parse(id),
                    ID_Пользователя = Guid.Parse(UserName.ToLower()),
                    Дата_отправки = DateTime.Now,
                    Текст_сообщения = text
                };
                _context.Add(сообщение);
                Пользователь пользователь = _context.Пользователь.FirstOrDefault(t => t.ID == Guid.Parse(UserName));
                var members = _context.Участник.Where(t => t.ID_беседы == Guid.Parse(id)).ToList();
                Беседа беседа = _context.Беседа.Include(t => t.Участники).FirstOrDefault(t => t.ID_Беседы == Guid.Parse(id));
                string conv_name = "";
                _context.SaveChanges();
                if (беседа.Участники.Count() == 2)
                {
                    foreach (var item in members)
                    {
                        var covertantId = members.FirstOrDefault(t => t.ID_Пользователя != item.ID_Пользователя).ID_Пользователя;
                        var covertant = _context.Пользователь.FirstOrDefault(t => t.ID == covertantId);
                        await Clients.User(item.ID_Пользователя.ToString().ToLower()).SendAsync("MessageSend", new
                        {
                            user_send = сообщение.ID_Пользователя,
                            conv_id = сообщение.ID_беседы,
                            conv_name = covertant.Фамилия + " " + covertant.Имя,
                            conv_user_id = covertant.ID,
                            date = сообщение.Дата_отправки.ToLongDateString(),
                            text = сообщение.Текст_сообщения,
                            firstname = пользователь.Имя,
                            secondname = пользователь.Фамилия
                        });
                    }
                }
                else 
                {
                    conv_name = беседа.Название_беседы;
                    foreach (var item in members)
                    {
                        var covertantId = members.FirstOrDefault(t => t.ID_Пользователя != item.ID_Пользователя).ID_Пользователя;
                        var covertant = _context.Пользователь.FirstOrDefault(t => t.ID == covertantId);
                        await Clients.User(item.ID_Пользователя.ToString().ToLower()).SendAsync("MessageSend", new
                        {
                            user_send = сообщение.ID_Пользователя,
                            conv_id = сообщение.ID_беседы,
                            conv_name = covertant.Фамилия + " " + covertant.Имя,
                            conv_user_id = covertant.ID,
                            date = сообщение.Дата_отправки.ToLongDateString(),
                            text = сообщение.Текст_сообщения,
                            firstname = пользователь.Имя,
                            secondname = пользователь.Фамилия
                        });
                    }
                }
            }            
        }
    }
}
