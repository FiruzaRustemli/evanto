using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Evanto.Resources.Operations.Booking.ChangeStatus;
using Evanto.BL.DTOs.Vendor;

namespace Evanto.BL.Operations.BookingOperations
{
    public class ChangeStatusBookingByVendorInput : OperationParameters
    {
        [Range(1, int.MaxValue, ErrorMessageResourceName = "BookingIdIsRequired", ErrorMessageResourceType = typeof(ChangeStatusBookingResource))]
        public int Id { get; set; }
        [Range(1, int.MaxValue, ErrorMessageResourceName = "StatusIdIsRequired", ErrorMessageResourceType = typeof(ChangeStatusBookingResource))]
        public int StatusId { get; set; }
         
    }
    public class ChangeStatusBookingByVendorOutput
    {
        public BookingVendorDto Booking { get; set; }
        public bool IsUpdated { get; set; } = false;
    }
}
