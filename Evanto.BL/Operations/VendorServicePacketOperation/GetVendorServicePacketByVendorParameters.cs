using System.Collections.Generic;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.Vendor;

namespace Evanto.BL.Operations.VendorServicePacketOperation
{
    public class GetVendorServicePacketByVendorInput : OperationParameters
    {
        public int? Id { get; set; }

        public int? StatusId { get; set; }

        public int? DiscountCouponId { get; set; }

        public int? PaymentId { get; set; }

    }

    public class  GetVendorServicePacketByVendorOutput
    {
        public List<VendorServicePacketVendorDto> VendorServicePackets { get; set; } = new List<VendorServicePacketVendorDto>();
    }
}
