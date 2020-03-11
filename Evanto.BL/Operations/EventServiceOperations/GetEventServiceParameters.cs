using System;
using System.Collections.Generic;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.EventServiceOperations
{
    public class GetEventServiceInput : OperationParameters
    {
        public int? Id { get; set; }
        public int? EventId { get; set; }
        public int? ServiceId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
    }
    public class GetEventServiceOutput
    {
        public List<EventServiceDto> EventServices { get; set; }
    }
}
