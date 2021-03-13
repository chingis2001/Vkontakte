using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Vkontakte.Models
{
    public class Запись
    {
        public Запись() 
        {
            Действия = new List<Дествие>();
            Коментарии = new List<Коментарий>();
            Приложения = new List<Приложение>();
        }
        [Key]
        public Guid ID_Записи { get; set; }
        public string Название { get; set; }
        public string Текст { get; set; }
        public byte Удалён { get; set; }
        public DateTime Дата_публикации { get; set; }
        public Guid ID_Блога { get; set; }
        public Блог Блог { get; set; }
        public IEnumerable<Дествие> Действия { get; set; }
        public IEnumerable<Коментарий> Коментарии { get; set; }
        public IEnumerable<Приложение> Приложения { get; set; }
    }
}
