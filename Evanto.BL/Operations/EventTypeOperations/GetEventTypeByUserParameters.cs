using System.Collections.Generic;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;

namespace Evanto.BL.Operations.EventTypeOperations
{
    public class GetEventTypeByUserInput : OperationParameters
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }

    public class GetEventTypeByUserOutput
    {
        public List<EventTypeUserDto> EventTypes { get; set; }
    }
}
