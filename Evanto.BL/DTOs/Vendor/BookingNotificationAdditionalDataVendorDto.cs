using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.Vendor
{
    public class BookingNotificationAdditionalDataVendorDto
    {
        public int BookingId { get; set; }
        public int OldStatusId { get; set; }
        public int NewStatusId { get; set; }
        public string ResourceKey { get; set; }
    }
}
