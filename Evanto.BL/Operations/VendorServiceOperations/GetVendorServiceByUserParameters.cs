using System.Collections.Generic;
using System.Linq.Expressions;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;

namespace Evanto.BL.Operations.VendorServiceOperations
{
    public class GetVendorServiceByUserInput : OperationParameters
    {
        public FilterUserDto Filter { get; set; } = new FilterUserDto();
        public int? ServiceId { get; set; }
        public int EventTypeId { get; set; }
        public int?  VendorId { get; set; }
    }
    public class GetVendorServiceByUserOutput
    {
        public PagedUserDto<VendorServiceUserDto> VendorServices { get; set; } = new PagedUserDto<VendorServiceUserDto>();
    }
}
