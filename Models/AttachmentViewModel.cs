using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vkontakte.Models
{
    public class AttachmentViewModel
    {
        public Guid ID_Записи { get; set; }
        public IFormFile Attachment { get; set; }
    }
}
