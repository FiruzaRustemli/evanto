using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.VendorServicePacketOperation
{
    public class DeactivateStatusVSPByVendorInput : OperationParameters
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
    }

    public class DeactivateStatusVSPByVendorOutput
    {
        public bool IsDeactivated { get; set; }
    }
}
