using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vkontakte.Models
{
    public class Приложение
    {
        public Guid ID_Data { get; set; }
        public Guid ID_Записи { get; set; }
        public Запись Запись { get; set; }
        public Данные Данные { get; set; }
        public int Тип { get; set; }
    }
}
