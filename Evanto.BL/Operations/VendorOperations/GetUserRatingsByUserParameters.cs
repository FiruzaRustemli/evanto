using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;
using Evanto.BL.DTOs.Vendor;
using Evanto.Resources.Operations.Vendor.Get;

namespace Evanto.BL.Operations.VendorOperations
{
    public class GetUserRatingsByUserInput : OperationParameters
    {
        public int VendorServiceId { get; set; }
    }
    public class GetUserRatingsByUserOutput
    {
        public List<VendorServiceRatingUserDto> Ratings { get; set; } = new List<VendorServiceRatingUserDto>();
    }
}
