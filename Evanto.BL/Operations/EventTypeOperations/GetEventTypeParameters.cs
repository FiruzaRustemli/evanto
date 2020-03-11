using System.Collections.Generic;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.EventTypeOperations
{
    public class GetEventTypeInput : OperationParameters
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }

    public class GetEventTypeOutput
    {
        public List<EventTypeDto> EventTypes { get; set; }
    }
}
