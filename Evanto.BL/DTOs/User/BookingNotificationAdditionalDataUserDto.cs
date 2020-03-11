using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.User
{
    public class BookingNotificationAdditionalDataUserDto
    {
        public int BookingId { get; set; }
        public string ResourceKey { get; set; }

        public string UserName { get; set; }
        public string VendorServiceName { get; set; }
    }
}
