using Evanto.BL.DTOs.Vendor;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.VendorServicePacketOperation
{
    public class AddVendorServicePacketInput : OperationParameters
    {
        public Payment Payment { get; set; }
        public string CouponNumber { get; set; }
        public int VendorServicePacketStatusId { get; set; }
        public int VendorId { get; set; }
    }
    public class AddVendorServicePacketOutput
    {
        public bool IsCreated { get; set; }
        public VendorServicePacketVendorDto VendorServicePacket { get; set; }
    }
}
