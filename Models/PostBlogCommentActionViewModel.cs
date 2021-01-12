using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vkontakte.Models
{
    public class PostBlogCommentActionViewModel
    {
        public PostBlogCommentActionViewModel() 
        {
            Коментарии = new List<Коментарий>();
            Дествия = new List<Дествие>();
            Данные = new List<Данные>();
        }
        public Запись Запись { get; set; }
        public Блог Блог { get; set; }
        public IEnumerable<Коментарий> Коментарии { get; set; }
        public IEnumerable<Дествие> Дествия { get; set; }
        public IEnumerable<Данные> Данные { get; set; }
    }
}
