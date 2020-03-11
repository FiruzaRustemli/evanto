using System.Collections.Generic;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.VendorServicePacketStatusOperation
{
    public class GetVendorServicePacketStatusInput:OperationParameters
    {

    }

    public class GetVendorServicePacketStatusOutput
    {
        public List<VendorServicePacketStatusDto> VendorServicePacketStatus { get; set; }
    }

}
