using System.ComponentModel.DataAnnotations;

namespace Evanto.BL.Operations.EventTypeOperations
{
    public class CreateEventTypeInput : OperationParameters
    {
        [Required(ErrorMessage = "Status Is required!")]
        public bool Status { get; set; } = true;

        [Required(ErrorMessage = "NameEn Is required!")]
        [MaxLength(50,ErrorMessage = "NameEn  must be less than  50 character")]
        public string NameEn { get; set; }

        [Required(ErrorMessage = "NameAz Is required!")]
        [MaxLength(50,ErrorMessage = "NameAz  must be less than  50 character")]
        public string NameAz { get; set; }

        [Required(ErrorMessage = "NameRu Is required!")]
        [MaxLength(50,ErrorMessage = "NameRu  must be less than  50 character")]
        public string NameRu { get; set; }
        
        [MaxLength(50, ErrorMessage = "Name  must be less than  50 character")]
        public string Description { get; set; }
    }

    public class CreateEventTypeOutput
    {
        public bool IsCreated { get; set; } = false;
    }
}
