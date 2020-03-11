using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.Web.Vendor.Models
{
    public class CreateAvatarInput
    {
        public string MediaType { get; set; }
        [MaxLength(300000000)]
        public string Container { get; set; }

        public string Extension { get; set; }
    }
}
