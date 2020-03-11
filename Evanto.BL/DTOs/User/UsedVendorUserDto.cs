using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.User
{
    public class UsedVendorUserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ConfirmedRequestCount { get; set; }
        public int RejectedRequestCount { get; set; }
        public int WaitingRequestCount { get; set; }
        public virtual VendorUserUserDto User { get; set; }
    }
}
