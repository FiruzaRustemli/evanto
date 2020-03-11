using Evanto.BL.DTOs.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.VendorOperations
{
    public class UpdateVendorContactInformationsInput: OperationParameters
    {
        public string Address { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
    }

    public class UpdateVendorContactInformationsOutput
    {
        public ContactInformationVendorDto ContactInformation { get; set; }
        public bool IsUpdated { get; set; }
    }
}
