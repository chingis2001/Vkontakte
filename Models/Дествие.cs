using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vkontakte.Models
{
    public class Дествие
    {
        public DateTime Дата_действия { get; set; }
        public Guid ID_Пользователя { get; set; }
        public Пользователь Пользователь { get; set; }
        public Guid ID_Записи { get; set; }
        public Запись Запись { get; set; }
        public int Код { get; set; }
        public Тип_действия Тип_Действия { get; set; }
    }
}
