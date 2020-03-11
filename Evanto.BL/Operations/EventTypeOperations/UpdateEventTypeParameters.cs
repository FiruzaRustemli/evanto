using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.EventTypeOperations
{
    public class UpdateEventInput : OperationParameters
    {
        [Required(ErrorMessage = "Id Is required!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Status Is required!")]
        public bool Status { get; set; }

       
        public string Name { get; set; }

        [Required(ErrorMessage = "NameEn Is required!")]
        [MaxLength(50, ErrorMessage = "NameEn  must be less than  50 character")]
        public string NameEn { get; set; }

        [Required(ErrorMessage = "NameAz Is required!")]
        [MaxLength(50, ErrorMessage = "NameAz  must be less than  50 character")]
        public string NameAz { get; set; }

        [Required(ErrorMessage = "NameRu Is required!")]
        [MaxLength(50, ErrorMessage = "NameRu  must be less than  50 character")]
        public string NameRu { get; set; }

        [MaxLength(50, ErrorMessage = "Name  must be less than  50 character")]
        public string Description { get; set; }
    }
    public class UpdateEventOutput
    {
        public bool IsUpdated { get; set; }
        public EventTypeDto EventType { get; set; }
    }
}