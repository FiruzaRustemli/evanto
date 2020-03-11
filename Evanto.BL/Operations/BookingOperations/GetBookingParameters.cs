using System;
using System.Collections.Generic;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;

namespace Evanto.BL.Operations.BookingOperations
{
    public class GetBookingInput : OperationParameters
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public int? VendorId { get; set; }
        public int? UserServiceId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? BookDate { get; set; }
        public DateTime? DeadLine { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime? CreatedTime { get; set; }
    }

    public class GetBookingOutput
    {
        public List<BookingDto> Bookings { get; set; }
    }
}
