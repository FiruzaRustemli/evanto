using Evanto.BL.DTOs.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.BookingOperations
{
    public class GetBookingByVendorInput: OperationParameters
    {
        public int StatusId { get; set; }
        public DateTime? Date { get; set; }
    }
    public class GetBookingByVendorOutput
    {
        public List<BookingVendorDto> Bookings { get; set; }
    }
}
