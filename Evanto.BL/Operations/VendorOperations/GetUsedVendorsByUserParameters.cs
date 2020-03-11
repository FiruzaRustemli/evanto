using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;
using Evanto.BL.DTOs.Vendor;
using Evanto.Resources.Operations.Vendor.Get;

namespace Evanto.BL.Operations.VendorOperations
{
    public class GetUsedVendorsByUserInput : OperationParameters
    {
    }
    public class GetUsedVendorsByUserOutput
    {
        public List<UsedVendorUserDto> Vendors { get; set; } = new List<UsedVendorUserDto>();
    }
}
