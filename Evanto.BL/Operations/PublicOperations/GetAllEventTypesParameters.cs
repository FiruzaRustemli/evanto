using System.Collections.Generic;
using Evanto.BL.DTOs.Public;

namespace Evanto.BL.Operations.PublicOperations
{
    public class GetAllEventTypesInput : OperationParameters
    {
       
    }
    public class GetAllEventTypesOutput
    {
        public List<EventTypePublicDto> EventTypes { get; set; } = new List<EventTypePublicDto>();
    }
}
