using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vkontakte.Models
{
    public class Коментарий
    {
        public string Текст_коментария { get; set; }
        public Guid ID_коментария { get; set; }
        public Guid ID_Пользователя { get; set; }
        public DateTime Дата_коментария { get; set; }
        public Пользователь Пользователь { get; set; }
        public Guid ID_Записи { get; set; }
        public Запись Запись { get; set; }
    }
}
