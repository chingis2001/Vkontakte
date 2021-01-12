using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vkontakte.Models
{
    public class UsersWithCommon
    {
        [Key]
        public Guid ID { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Город { get; set; }
        public string Страна { get; set; }
        public int Количество_общих_друзей { get; set; }
    }
}
