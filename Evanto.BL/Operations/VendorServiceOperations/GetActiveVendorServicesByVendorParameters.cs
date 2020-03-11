using Evanto.BL.DTOs.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.VendorServiceOperations
{
    public class GetActiveVendorServicesByVendorInput : OperationParameters
    {
    }

    public class GetActiveVendorServicesByVendorOutput
    {
        public List<VendorServiceVendorDto> VendorServices { get; set; } = new List<VendorServiceVendorDto>();
    }
}
