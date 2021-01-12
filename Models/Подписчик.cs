using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vkontakte.Models
{
    public class Подписчик
    {
        public Guid ID_Пользователя { get; set; }
        public Пользователь Пользователь { get; set; }
        public Guid ID_Блога { get; set; }
        public Блог Блог { get; set; }
    }
}
