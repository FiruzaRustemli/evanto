using System.ComponentModel.DataAnnotations;
using Evanto.Resources.Operations.EventService.Create;

namespace Evanto.BL.Operations.EventServiceOperations
{
    public class CreateEventServicesInput : OperationParameters
    {
        [Range(1, int.MaxValue, ErrorMessageResourceName = "IdIsRequired", ErrorMessageResourceType = typeof(CreateEventServiceResource))]
        public int Id { get; set; }
        [Range(1, int.MaxValue, ErrorMessageResourceName = "EventIdIsRequired", ErrorMessageResourceType = typeof(CreateEventServiceResource))]
        public int EventId { get; set; }
        [Range(1, int.MaxValue, ErrorMessageResourceName = "ServiceIdIsRequired", ErrorMessageResourceType = typeof(CreateEventServiceResource))]
        public int ServiceId { get; set; }
    }

    public class CreateEventServicesOutput
    {
        public bool IsCreated { get; set; } = false;
    }
}
