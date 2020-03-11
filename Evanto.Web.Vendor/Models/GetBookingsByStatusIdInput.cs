using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.Web.Vendor.Models
{
    public class GetBookingsByStatusIdInput
    {
        public int StatusId { get; set; }
        public int VendorId { get; set; }
    }
}
