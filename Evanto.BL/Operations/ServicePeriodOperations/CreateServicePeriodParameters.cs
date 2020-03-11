using System.ComponentModel.DataAnnotations;

namespace Evanto.BL.Operations.ServicePeriodOperations
{
    public class CreateServicePeriodInput : OperationParameters
    {
        [Required(ErrorMessage = "NameEn Is required!")]
        [MaxLength(50, ErrorMessage = "NameEn  must be less than  50 character")]
        public string NameEn { get; set; }

        [Required(ErrorMessage = "NameAz Is required!")]
        [MaxLength(50, ErrorMessage = "NameAz  must be less than  50 character")]
        public string NameAz { get; set; }

        [Required(ErrorMessage = "NameRu Is required!")]
        [MaxLength(50, ErrorMessage = "NameRu  must be less than  50 character")]
        public string NameRu { get; set; }

        [MaxLength(50, ErrorMessage = "Description must be less than 50 character")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Name Is Required")]
        [Range(1,int.MaxValue,ErrorMessage = "Duration Must be integer")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Status Is Required")]
        public bool Status { get; set; }
    }
    public class CreateServicePeriodOutput
    {
        public bool IsCreated { get; set; }
    }
}
