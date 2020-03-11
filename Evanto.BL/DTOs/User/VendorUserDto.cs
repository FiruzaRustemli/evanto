using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.User
{
    public class VendorUserDto
    {
        public int UserId { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public virtual VendorUserUserDto User { get; set; }
    }
}
