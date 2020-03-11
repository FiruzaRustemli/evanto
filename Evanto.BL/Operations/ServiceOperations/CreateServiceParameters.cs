using System.ComponentModel.DataAnnotations;
using Evanto.Resources.Operations.Service.Create;

namespace Evanto.BL.Operations.ServiceOperations
{
    public class CreateServiceInput : OperationParameters
    {
        [Required(ErrorMessage = "Status Is Required")]
        public bool Status { get; set; }
      
        [Required(ErrorMessage = "NameEn Is required!")]
        [MaxLength(50, ErrorMessage = "NameEn  must be less than  50 character")]
        public string NameEn { get; set; }

        [Required(ErrorMessage = "NameAz Is required!")]
        [MaxLength(50, ErrorMessage = "NameAz  must be less than  50 character")]
        public string NameAz { get; set; }

        [Required(ErrorMessage = "NameRu Is required!")]
        [MaxLength(50, ErrorMessage = "NameRu  must be less than  50 character")]
        public string NameRu { get; set; }

        public string Description { get; set; }
        [Required(ErrorMessage = "Price Is Required")]
        public decimal Price { get; set; }
    }
    public class CreateServiceOutput
    {
        public bool IsCreated { get; set; } = false;
    }
}
