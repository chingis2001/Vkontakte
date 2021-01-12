using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Vkontakte.Models
{
    public class Статус_дружбы
    {
        public Статус_дружбы() 
        {
            Дружбы = new List<Дружба>();
        }
        [Key]
        public int Код_статуса { get; set; }
        public string Наименование { get; set; }
        public IEnumerable<Дружба> Дружбы { get; set; }
    }
}
