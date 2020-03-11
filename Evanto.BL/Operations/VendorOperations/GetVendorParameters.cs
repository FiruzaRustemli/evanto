using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Admin;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.Vendor;
using Evanto.Resources.Operations.Vendor.Get;

namespace Evanto.BL.Operations.VendorOperations
{
    public class GetVendorInput : OperationParameters
    {
        //TODO
        public int? Id { get; set; }
        //[Required(ErrorMessageResourceName = "UserIdIsRequired", ErrorMessageResourceType = typeof(GetVendorResource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "UserIdRange", ErrorMessageResourceType = typeof(GetVendorResource))]
        public int? UserId { get; set; }
        //[Required(ErrorMessageResourceName = "AddressIsRequired", ErrorMessageResourceType = typeof(GetVendorResource))]
        [MinLength(3, ErrorMessageResourceName = "VendorAddressMinlength", ErrorMessageResourceType = typeof(GetVendorResource))]
        [MaxLength(200, ErrorMessageResourceName = "VendorAddressMaxlength", ErrorMessageResourceType = typeof(GetVendorResource))]
        public string Address { get; set; }
        public float? Rating { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class GetVendorOutput
    {
        public List<AdminVendorDto> Vendors { get; set; }
    }
}
