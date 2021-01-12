using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Vkontakte.Models
{
    public class Беседа
    {
        public Беседа() 
        {
            Участники = new List<Участник>();
        }
        [Key]
        public Guid ID_Беседы { get; set; }
        public string Название_беседы { get; set; }
        public string Описание_беседы { get; set; }
        public DateTime Дата_создания { get; set; }
        public IEnumerable<Участник> Участники { get; set; }
    }
}
