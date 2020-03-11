using Evanto.BL.DTOs.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.VendorOperations
{
    public class GetVendorByIdByVendorInput: OperationParameters
    {
    }
    public class GetVendorByIdByVendorOutput
    {
        public VendorVendorDto Vendor { get; set; }
    }
}
