using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vkontakte.Models;

namespace Vkontakte.Services
{
    public interface IFriendFee
    {
        List<UsersWithCommon> GetUsersWithCommon(Guid Id, socialnetworkContext context, int skip, int rows, string pattern, string city, string country);
    }
}
