using System;
using System.Collections.Generic;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;

namespace Evanto.BL.Operations.EventServiceOperations
{
    public class GetEventServiceByUserInput : OperationParameters
    {
        public int? Id { get; set; }
        public int? EventId { get; set; }
        public int? ServiceId { get; set; }
    }
    public class GetEventServiceByUserOutput
    {
        public List<EventServiceUserDto> EventServices { get; set; } = new List<EventServiceUserDto>();
    }
}
