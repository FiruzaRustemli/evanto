using System.ComponentModel.DataAnnotations;
using Evanto.BL.Operations.UserOperations;
using Evanto.Resources.Operations.Vendor.Create;

namespace Evanto.BL.Operations.VendorOperations
{
    public class CreateVendorInput : OperationParameters
    {
        [Required]
        public CreateUserInput UserInput { get; set; }
        
        [MinLength(3, ErrorMessageResourceName = "VendorAddressMinlength", ErrorMessageResourceType =(typeof(CreateVendorResource)))]
        [MaxLength(200, ErrorMessageResourceName = "VendorAddressMaxlength", ErrorMessageResourceType = (typeof(CreateVendorResource)))]
        public string Address { get; set; }
        public string Name { get; set; }
    }
    public class CreateVendorOutput
    {
        public bool IsCreated { get; set; }
    }
}
