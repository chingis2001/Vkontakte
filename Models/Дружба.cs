using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vkontakte.Models
{
    public class Дружба
    {
        public DateTime Дата_изиенения_статуса { get; set; }
        public Guid ID_Пользователя { get; set; }
        public Пользователь Пользователь { get; set; }
        public Guid ID_Друга { get; set; }
        public Пользователь Друг { get; set; }
        public int Код_статуса { get; set; }
        public Статус_дружбы Статус_Дружбы { get; set; }
    }
}
