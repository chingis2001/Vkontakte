using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vkontakte.Models
{
    public class MessagessWithUsersViewModel
    {
        public MessagessWithUsersViewModel() 
        {
            сообщения = new List<Сообщения>();
            пользователи = new List<Пользователь>();
        }
        public IEnumerable<Сообщения> сообщения { get; set; }
        public IEnumerable<Пользователь> пользователи { get; set; }
    }
}
