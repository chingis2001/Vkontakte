using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vkontakte.Models
{
    public class Участник
    {
        public Участник() 
        {
            Сообщения = new List<Сообщения>();
        }
        public DateTime Дата_последнего_просмотра { get; set; }
        public DateTime Дата_добавления { get; set; }
        public Guid ID_беседы { get; set; }
        public Беседа Беседа { get; set; }
        public Guid ID_Пользователя { get; set; }
        public Пользователь Пользователь { get; set; }
        public IEnumerable<Сообщения> Сообщения { get; set; }
    }
}
