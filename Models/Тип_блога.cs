using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Vkontakte.Models
{
    public class Тип_блога
    {
        public Тип_блога() 
        {
            Блоги = new List<Блог>();
        }
        [Key]
        public int Код_типа_блога { get; set; }
        public string Наименование { get; set; }
        public IEnumerable<Блог> Блоги { get; set; }
    }
}
