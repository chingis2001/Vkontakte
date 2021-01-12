using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vkontakte.Models
{
    public class TopicsTypesViewModel
    {
        public TopicsTypesViewModel() 
        {
            тематики = new List<Тематика>();
            типы = new List<Тип_блога>();
        }
        public List<Тематика> тематики { get; set; }
        public List<Тип_блога> типы { get; set; }
    }
}
