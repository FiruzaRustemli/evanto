using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.VendorServiceOperations
{
    public class ChangeStatusVendorServiceByVendorInput: OperationParameters
    {
        public int VendorServiceId { get; set; }
        public bool Status { get; set; }
    }

    public class ChangeStatusVendorServiceByVendorOutput
    {
        public int VendorServiceId { get; set; }
        public bool Status { get; set; }
        public bool IsUpdated { get; set; }
    }
}
