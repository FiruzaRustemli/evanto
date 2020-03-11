using Evanto.BL.DTOs.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.UserOperations
{
    public class GetUserInfoByBkngIdByVendorInput: OperationParameters
    {
        public int BookingId { get; set; }
    }
    
    public class GetUserInfoByBkngIdByVendorOutput
    {
        public BookingVendorDto Booking { get; set; }
        public UserVendorDto User { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
    }
}
