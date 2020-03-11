using Evanto.Web.Vendor.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.Web.Vendor.Models
{
    public class GetBookingOutput
    {
        public List<BookingDto> bookings { get; set; }
    }
}
