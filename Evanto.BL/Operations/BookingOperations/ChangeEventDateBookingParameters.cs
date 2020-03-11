using System;
using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Evanto.Resources.Operations.Booking.ChangeEventDate;

namespace Evanto.BL.Operations.BookingOperations
{
    public class ChangeEventDateBookingInput : OperationParameters
    {
        [Range(1, int.MaxValue, ErrorMessageResourceName = "BookingIdIsRequired", ErrorMessageResourceType = typeof(ChangeEventDateBookingResource))]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "DeadLineIsRequired", ErrorMessageResourceType = typeof(ChangeEventDateBookingResource))]
        public DateTime Deadline { get; set; }
    }
    public class ChangeEventDateBookingOutput
    {
        public bool IsUpdated { get; set; } = false;
        public BookingDto Booking { get; set; }
    }
}
