using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Vkontakte.Models
{
    public class AvatarViewModel
    {
        public Guid ID_Пользователя { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
