using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vkontakte.Models
{
    public class Данные
    {
        public Данные()
        {
            Приложения = new List<Приложение>();
            Аватарки = new List<Аватарка>();
        }
        public Guid ID { get; set; }
        public byte[] Data { get; set; }
        public IEnumerable<Приложение> Приложения { get; set; }
        public IEnumerable<Аватарка> Аватарки { get; set; }
    }
}
