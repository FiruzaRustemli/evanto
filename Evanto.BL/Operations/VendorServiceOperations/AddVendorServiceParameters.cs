using System.Collections.Generic;
using Evanto.BL.DTOs.Vendor;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.VendorServiceOperations
{
    public class AddVendorServicesInput: OperationParameters
    {
        public List<VendorService> VendorServices { get; set; }
        public Payment Payment { get; set; }
        public string CouponNumber { get; set; }
        public int VendorServicePacketStatusId { get; set; }
    }
    public class AddVendorServicesOutput
    {
        public bool IsCreated { get; set; }
        public VendorServicePacketVendorDto VendorServicePacket { get; set; }
    }
}
