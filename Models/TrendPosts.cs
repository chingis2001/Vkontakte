using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vkontakte.Models
{
    public class TrendPosts
    {
        public Guid ID { get; set; }
        public Guid BlogID { get; set; }
        public string text { get; set; }
        public DateTime publicationTime { get; set; }
        public int pic { get; set; }
        public int numberViews { get; set; }
    }
}
