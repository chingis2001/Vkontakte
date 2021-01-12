using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vkontakte.Models
{
    public class Блог
    {
        public Блог() 
        {
            Записи = new LinkedList<Запись>();
            Подписчики = new LinkedList<Подписчик>();
        }
        [Key]
        public Guid ID_Блога { get; set; }
        public string Название { get; set; }
        public string Описание { get; set; }
        public DateTime Дата_создания { get; set; }
        public int Код_типа_тематики { get; set; }
        public Тематика Тематика { get; set; }
        public int Код_типа { get; set; }
        public Тип_блога Тип_Блога { get; set; }
        public Guid ID_Создателя { get; set; }
        public Пользователь Пользователь { get; set; }
        public IEnumerable<Запись> Записи { get; set; }
        public IEnumerable<Подписчик> Подписчики { get; set; }
    }
}
