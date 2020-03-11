using System;
using System.ComponentModel.DataAnnotations;
using Evanto.Resources.Operations.Booking.Create;

namespace Evanto.BL.Operations.BookingOperations
{
    public class CreateBookingInput : OperationParameters
    {
        //[Range(1, int.MaxValue, ErrorMessageResourceName = "VendorIdIsRequired", ErrorMessageResourceType = typeof(CreateBookingResource))]
        public int VendorId { get; set; }
        //[Range(1, int.MaxValue, ErrorMessageResourceName = "UserServiceIdIsRequired", ErrorMessageResourceType = typeof(CreateBookingResource))]
        public int UserServiceId { get; set; }
        //[Required(ErrorMessageResourceName = "BookDateIsRequired", ErrorMessageResourceType = typeof(CreateBookingResource))]
        public DateTime BookDate { get; set; }
        //[Required(ErrorMessageResourceName = "EventDateIsRequired", ErrorMessageResourceType = typeof(CreateBookingResource))]
        public DateTime EventDate { get; set; }
        public DateTime DeadLine { get; set; }
        public int VendorServiceId { get; set; }
    }
    public class CreateBookingOutput
    {
        public bool IsCreated { get; set; } = false;
    }
}
