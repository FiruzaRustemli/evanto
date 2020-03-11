using System;
using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Evanto.Resources.Operations.Vendor.Update;

namespace Evanto.BL.Operations.VendorOperations
{
    public class UpdateVendorInput : OperationParameters
    {
        public string Address { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public DateTime? Birthday { get; set; }


        public string Phone { get; set; }


        public string Username { get; set; }
    }

    public class UpdateVendorOutput
    {
        public VendorDto Vendor { get; set; }
        public bool IsUpdated { get; set; } = false;
    }
}
