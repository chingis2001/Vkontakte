using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vkontakte.Models
{
    public class Аватарка
    {
        public Guid ID_Data { get; set; }
        public Guid ID_Пользователя { get; set; }
        public DateTime Дата_изменения { get; set; }
        public bool Используется { get; set; }
        public Пользователь Пользователь { get; set; }
        public Данные Данные { get; set; }
    }
}
