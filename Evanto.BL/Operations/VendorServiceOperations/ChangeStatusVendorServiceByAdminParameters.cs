using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.VendorServiceOperations
{
    public class ChangeStatusVendorServiceByAdminInput: OperationParameters
    {
        public int Id { get; set; }
        public bool Status { get; set; }
    }

    public class ChangeStatusVendorServiceByAdminOutput
    {
        public int VendorServiceId { get; set; }
        public bool Status { get; set; }
        public bool IsUpdated { get; set; }
    }
}
