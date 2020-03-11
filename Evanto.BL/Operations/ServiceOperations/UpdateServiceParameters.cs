using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Evanto.Resources.Operations.Service.Update;

namespace Evanto.BL.Operations.ServiceOperations
{
    public class UpdateServiceInput : OperationParameters
    {
        [Required(ErrorMessage = "Id Is Required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Status Is Required")]
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

        public string Description { get; set; }
        [Required(ErrorMessage = "Price Is Required")]
        public decimal Price { get; set; }
    }

    public class UpdateServiceOutput
    {
        public bool IsUpdated { get; set; } = false;
        public ServiceDto Service { get; set; }
    }
}

