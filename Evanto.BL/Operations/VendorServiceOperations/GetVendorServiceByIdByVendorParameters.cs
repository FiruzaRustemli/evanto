using Evanto.BL.DTOs.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.VendorServiceOperations
{
    public class GetVendorServiceByIdByVendorInput: OperationParameters
    {
        public int Id { get; set; }
    }

    public class GetVendorServiceByIdByVendorOutput
    {
        public VendorServiceVendorDto VendorService { get; set; }
    }
}
