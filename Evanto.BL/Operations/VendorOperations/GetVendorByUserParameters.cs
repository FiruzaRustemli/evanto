using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;
using Evanto.BL.DTOs.Vendor;
using Evanto.Resources.Operations.Vendor.Get;

namespace Evanto.BL.Operations.VendorOperations
{
    public class GetVendorByUserInput : OperationParameters
    {
        //TODO
        //[Required(ErrorMessageResourceName = "UserIdIsRequired", ErrorMessageResourceType = typeof(GetVendorResource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "UserIdRange", ErrorMessageResourceType = typeof(GetVendorResource))]
        public int VendorId { get; set; }
    }
    public class GetVendorByUserOutput
    {
        public VendorUserDto Vendor;
    }
}
