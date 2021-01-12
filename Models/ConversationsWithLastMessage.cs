using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vkontakte.Models
{
    public class ConversationsWithLastMessage
    {
        public ConversationsWithLastMessage() 
        {
            Пользователь = new List<Пользователь>();
        }
        public IEnumerable<Пользователь> Пользователь { get; set; }
        public Беседа беседа { get; set; }
        public Сообщения сообщение { get; set; }
    }
}
