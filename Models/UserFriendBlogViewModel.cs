using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vkontakte.Models
{
    public class UserFriendBlogViewModel
    {
        public UserFriendBlogViewModel() 
        {
            дружбы = new List<Дружба>();
        }
        public Пользователь пользователь { get; set; }
        public IEnumerable<Дружба> дружбы { get; set; }
        public int CountFollowers { get; set; }
        public int CountBlogs { get; set; }
        public Аватарка Аватарка { get; set; }
    }
}
