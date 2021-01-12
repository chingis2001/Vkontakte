using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Vkontakte.Models
{
    public class Тип_действия
    {
        public Тип_действия() 
        {
            Действия = new List<Дествие>();
        }
        [Key]
        public int Код_действия { get; set; }
        public string Название { get; set; }
        public IEnumerable<Дествие> Действия { get; set; }
    }
}
