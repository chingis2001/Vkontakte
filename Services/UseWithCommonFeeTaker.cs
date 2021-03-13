using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Vkontakte.Models;

namespace Vkontakte.Services
{
    public class UseWithCommonFeeTaker : IFriendFee
    {
        public List<UsersWithCommon> GetUsersWithCommon(Guid Id, socialnetworkContext context, int skip, int rows, string pattern, string city, string country) 
        {
            SqlParameter parameter = new SqlParameter("@ID", Id);
            SqlParameter skipparam = new SqlParameter("@skip", skip);
            SqlParameter rowsparam = new SqlParameter("@rows", rows);
            SqlParameter patternparam = new SqlParameter("@pattern", pattern);
            SqlParameter cityparam = new SqlParameter("@city", city);
            SqlParameter countryparam = new SqlParameter("@country", country);
            var Users = context.users.FromSqlRaw("GetCommonFriends @ID, @skip, @rows, @pattern, @city, @country", new SqlParameter[] { parameter, skipparam, rowsparam, patternparam, cityparam, countryparam }).ToList();
            return Users;
        }
    }
}
