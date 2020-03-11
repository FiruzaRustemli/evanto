using System.ComponentModel.DataAnnotations;
using Evanto.Resources.Operations.VendorServiceExceptionalEvent.Create;

namespace Evanto.BL.Operations.VendorServiceExceptionalEventOperations
{
    public class CreateVendorServiceExceptionalEventInput : OperationParameters
    {
        [Required(ErrorMessageResourceName = "VendorServiceIdIsRequired", ErrorMessageResourceType = typeof(CreateVendorServiceExceptionalEventResource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "VendorServiceIdRange", ErrorMessageResourceType = typeof(CreateVendorServiceExceptionalEventResource))]
        public int VendorServiceId { get; set; }
        
        [Required(ErrorMessageResourceName = "EventIdIsRequired", ErrorMessageResourceType = typeof(CreateVendorServiceExceptionalEventResource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "EventIdRange", ErrorMessageResourceType = typeof(CreateVendorServiceExceptionalEventResource))]
        public int EventId { get; set; }

        [MinLength(3, ErrorMessageResourceName = "DescriptionMinlength", ErrorMessageResourceType = typeof(CreateVendorServiceExceptionalEventResource))]
        [MaxLength(50, ErrorMessageResourceName = "DescriptionMaxlength", ErrorMessageResourceType = typeof(CreateVendorServiceExceptionalEventResource))]
        public string Description { get; set; }
    }
    public class CreateVendorServiceExceptionalEventOutput
    {
        public bool IsCreated { get; set; } = false;
    }
}
