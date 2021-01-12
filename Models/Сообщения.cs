using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Vkontakte.Models
{
    public class Сообщения
    {
        [Key]
        public Guid ID_Сообщения { get; set; }
        public string Текст_сообщения { get; set; }
        public DateTime Дата_отправки { get; set; }
        public Guid ID_беседы { get; set; }
        public Guid ID_Пользователя { get; set; }
        public Участник Участник { get; set; }
    }
}
