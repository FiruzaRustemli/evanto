using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.Web.Vendor.Models
{
    public class CreateBookingInput
    {
        public int VendorId { get; set; }
        public DateTime BookDate { get; set; }
        public DateTime DeadLine { get; set; }
        public string Description { get; set; }
    }
}
