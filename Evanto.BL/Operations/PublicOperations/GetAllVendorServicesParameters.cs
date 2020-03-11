using System.Collections.Generic;
using Evanto.BL.DTOs.Public;
using Evanto.BL.DTOs.User;
using System;
using System.ComponentModel.DataAnnotations;

namespace Evanto.BL.Operations.PublicOperations
{
    public class GetAllVendorServicesInput : OperationParameters
    {
        [Required]
        public FilterUserDto Filter { get; set; } = new FilterUserDto();
        public int[] ServiceIds { get; set; }
        public int[] EventTypeIds { get; set; }
        public byte[] Ratings { get; set; }
        public DateTime? Date { get; set; }
        public int? MinPrice { get; set; }   
        public int? MaxPrice { get; set; }   
    }
    public class GetAllVendorServicesOutput
    {
        public PagedUserDto<VendorServicePublicDto> VendorServices { get; set; } = new PagedUserDto<VendorServicePublicDto>();
    }
}
