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
        public List<UsersWithCommon> GetUsersWithCommon(Guid Id, socialnetworkContext context, int skip, int rows) 
        {
            SqlParameter parameter = new SqlParameter("@ID", Id);
            SqlParameter skipparam = new SqlParameter("@skip", skip);
            SqlParameter rowsparam = new SqlParameter("@rows", rows);
            var Users = context.users.FromSqlRaw("GetCommonFriends @ID, @skip, @rows", new SqlParameter[] { parameter, skipparam, rowsparam }).ToList();
            return Users;
        }
    }
}
