using System.Collections.Generic;
using Evanto.BL.DTOs.Admin;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.VendorServicePacketOperation
{
    public class GetVendorServicePacketInput : OperationParameters
    {
        public int? Id { get; set; }

        public int? StatusId { get; set; }

        public int? DiscountCouponId { get; set; }

        public int? PaymentId { get; set; }

    }

    public class  GetVendorServicePacketOutput
    {
        public List<VendorServicePacketByAdminDto> VendorServicePackets { get; set; } = new List<VendorServicePacketByAdminDto>();
    }
}
