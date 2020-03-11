﻿using System.Collections.Generic;
using System.Linq.Expressions;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;

namespace Evanto.BL.Operations.VendorServiceOperations
{
    public class GetVendorServiceByAdminInput : OperationParameters
    {
        public int? Id { get; set; }
        public int? VendorServicePacketId { get; set; }
        public int? ServicePeriodPriceId { get; set; }
        public int? ServiceId { get; set; }
    }
    public class GetVendorServiceByAdminOutput
    {
        public List<VendorServiceUserDto> VendorServices { get; set; } = new List<VendorServiceUserDto>();
    }
}
