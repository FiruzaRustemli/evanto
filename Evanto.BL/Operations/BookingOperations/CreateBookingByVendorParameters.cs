using System;
using System.ComponentModel.DataAnnotations;
using Evanto.Resources.Operations.Booking.Create;
using Evanto.BL.DTOs.Vendor;

namespace Evanto.BL.Operations.BookingOperations
{
    public class CreateBookingByVendorInput : OperationParameters
    {
        //[Range(1, int.MaxValue, ErrorMessageResourceName = "VendorIdIsRequired", ErrorMessageResourceType = typeof(CreateBookingResource))]
        //[Required(ErrorMessageResourceName = "BookDateIsRequired", ErrorMessageResourceType = typeof(CreateBookingResource))]
        public DateTime BookDate { get; set; }
        //[Required(ErrorMessageResourceName = "EventDateIsRequired", ErrorMessageResourceType = typeof(CreateBookingResource))]
        public DateTime DeadLine { get; set; }
        public string Description { get; set; }
        public int VendorServiceId { get; set; }
    }
    public class CreateBookingByVendorOutput
    {
        public BookingVendorDto Booking { get; set; }
        public int BookingId { get; set; }
        public bool IsCreated { get; set; } = false;
    }
}
