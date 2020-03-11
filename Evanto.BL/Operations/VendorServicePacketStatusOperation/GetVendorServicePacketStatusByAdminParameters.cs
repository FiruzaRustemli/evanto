using System.Collections.Generic;
using Evanto.BL.DTOs.Admin;

namespace Evanto.BL.Operations.VendorServicePacketStatusOperation
{
    public class GetVendorServicePacketStatusByAdminInput:OperationParameters
    {

    }

    public class GetVendorServicePacketStatusByAdminOutput
    {
        public List<VendorServicePacketStatusByAdminDto> VendorServicePacketStatus { get; set; }
    }

}
