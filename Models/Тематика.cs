using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vkontakte.Models
{
    public class Тематика
    {
        public Тематика() 
        {
            Блоги = new List<Блог>();
        }
        [Key]
        public int Код_типа_тематики { get; set; }
        public string Наименование { get; set; }
        public IEnumerable<Блог> Блоги { get; set; }
    }
}
