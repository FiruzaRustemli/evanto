using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.VendorOperations
{
    public class CheckEmailAndPhoneInput: OperationParameters
    {
        public string Email { get; set; }
        public string Phone { get; set; }
    }
    public class CheckEmailAndPhoneOutput
    {
    }
}
