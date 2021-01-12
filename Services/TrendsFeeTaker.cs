using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vkontakte.Models;

namespace Vkontakte.Services
{
    public class TrendsFeeTaker : ITrendsFee
    {
        public List<TrendPosts> GetTrends(socialnetworkContext context) 
        {
            var Users = context.trends.ToList();
            return Users;
        }
    }
}
