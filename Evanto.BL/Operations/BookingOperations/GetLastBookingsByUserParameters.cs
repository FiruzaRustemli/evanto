using System;
using System.Collections.Generic;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;

namespace Evanto.BL.Operations.BookingOperations
{
    public class GetLastBookingsByUserInput : OperationParameters
    {
    }

    public class GetLastBookingsByUserOutput
    {
        public List<BookingUserDto> Bookings { get; set; }
    }
}
