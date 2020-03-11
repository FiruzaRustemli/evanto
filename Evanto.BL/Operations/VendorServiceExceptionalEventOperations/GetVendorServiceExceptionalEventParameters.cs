using System;
using System.Collections.Generic;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.VendorServiceExceptionalEventOperations
{
    public class GetVendorServiceExceptionalEventInput : OperationParameters
    {
        public int? Id { get; set; }
        public int? VendorServiceId { get; set; }
        public int? EventId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class GetVendorServiceExceptionalEventOutput
    {
        public List<VendorServiceExceptionalEventDto> VendorExceptionalEvents { get; set; }
    }
}
