using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;

namespace Evanto.BL.Operations.VendorServiceOperations
{
    public class GetTopVendorServicesByUserInput : OperationParameters
    {
        public int? Id { get; set; }
        public int? VendorServicePacketId { get; set; }
        public int? ServicePeriodPriceId { get; set; }
        public int? ServiceId { get; set; }
        public int? VendorId { get; set; }
        public List<int> ServiceIds { get; set; } = new List<int>();
        public int EventTypeId { get; set; }
    }
    public class GetTopVendorServicesByUserOutput
    {
        public IEnumerable<VendorServiceUserDto> VendorServices { get; set; } =  new List<VendorServiceUserDto>();
    }
}
