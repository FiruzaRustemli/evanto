using System.Collections.Generic;
using Evanto.BL.DTOs.Admin;

namespace Evanto.BL.Operations.BookingOperations
{
    public class GetBookingByAdminInput: OperationParameters
    {
        public int StatusId { get; set; }
        public int VendorId { get; set; }
    }
    public class GetBookingByAdminOutput
    {
        public List<BookingAdminDto> Bookings { get; set; }
    }
}
