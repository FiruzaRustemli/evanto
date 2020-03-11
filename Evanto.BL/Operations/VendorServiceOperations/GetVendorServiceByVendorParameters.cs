using System.Collections.Generic;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.Vendor;

namespace Evanto.BL.Operations.VendorServiceOperations
{
    public class GetVendorServiceByVendorInput : OperationParameters
    {
        public int? Id { get; set; }
        public int? VendorServicePacketId { get; set; }
        public int? ServicePeriodPriceId { get; set; }
        public int? ServiceId { get; set; }
        public List<int> ServiceIds { get; set; } = new List<int>();
    }
    public class GetVendorServiceByVendorOutput
    {
        public List<VendorServiceVendorDto> VendorServices { get; set; } = new List<VendorServiceVendorDto>();
    }
}
