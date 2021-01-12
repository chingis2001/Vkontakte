using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vkontakte.Models;

namespace Vkontakte.Services
{
    public interface ITrendsFee
    {
        List<TrendPosts> GetTrends(socialnetworkContext context);
    }
}
