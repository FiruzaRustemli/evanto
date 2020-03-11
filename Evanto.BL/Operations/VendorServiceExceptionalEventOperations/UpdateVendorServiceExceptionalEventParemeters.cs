using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Evanto.Resources.Operations.VendorServiceExceptionalEvent.Update;

namespace Evanto.BL.Operations.VendorServiceExceptionalEventOperations
{
    public class UpdateVendorServiceExceptionalEventInput : OperationParameters
    {
        [Required(ErrorMessageResourceName = "IdIsRequired", ErrorMessageResourceType = typeof(UpdateVendorServiceExceptionalEventResource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "IdRange", ErrorMessageResourceType = typeof(UpdateVendorServiceExceptionalEventResource))]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "VendorServiceIdIsRequired", ErrorMessageResourceType = typeof(UpdateVendorServiceExceptionalEventResource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "VendorServiceIdRange", ErrorMessageResourceType = typeof(UpdateVendorServiceExceptionalEventResource))]
        public int VendorServiceId { get; set; }

        [Required(ErrorMessageResourceName = "EventIdIsRequired", ErrorMessageResourceType = typeof(UpdateVendorServiceExceptionalEventResource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "EventIdRange", ErrorMessageResourceType = typeof(UpdateVendorServiceExceptionalEventResource))]
        public int EventId { get; set; }

        [MinLength(3, ErrorMessageResourceName = "DescriptionMinlength", ErrorMessageResourceType = typeof(UpdateVendorServiceExceptionalEventResource))]
        [MaxLength(50, ErrorMessageResourceName = "DescriptionMaxlength", ErrorMessageResourceType = typeof(UpdateVendorServiceExceptionalEventResource))]
        public string Description { get; set; }
    }
    public class UpdateVendorServiceExceptionalEventOutput
    {
        public VendorServiceExceptionalEventDto VendorServiceExceptionalEvent { get; set; }
        public bool IsUpdated { get; set; }
    }
}
