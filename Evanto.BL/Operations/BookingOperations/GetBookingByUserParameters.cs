using System;
using System.Collections.Generic;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;

namespace Evanto.BL.Operations.BookingOperations
{
    public class GetBookingByUserInput : OperationParameters
    {
        public int? Id { get; set; }
        public int? VendorId { get; set; }
        public int? VendorServiceId { get; set; }
        public int? ServiceId { get; set; }
        public int? EventId { get; set; }
        public int? StatusId { get; set; }
        public string SearchText { get; set; }
    }

    public class GetBookingByUserOutput
    {
        public List<BookingUserDto> Bookings { get; set; }
    }
}
