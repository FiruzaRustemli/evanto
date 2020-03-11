using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.BL.DTOs.Public;
using Evanto.DAL.Context;
using Evanto.BL.DTOs.User;

namespace Evanto.BL.Operations.PublicOperations
{
    public class GetVendorServiceInput : OperationParameters
    {
        [Required]
        public int Id { get; set; }
    }

    public class GetVendorServiceOutput : OperationParameters
    {
        public VendorServicePublicDto VendorService { get; set; }
        public VendorPublicDto Vendor { get; set; }
        public List<RatingUserDto> UserRatings { get; set; } = new List<RatingUserDto>();
        public List<VendorServicePublicDto> OtherVendorServices { get; set; } = new List<VendorServicePublicDto>();
    }
}
