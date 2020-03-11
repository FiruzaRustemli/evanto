using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.BL.DTOs.Public;

namespace Evanto.BL.Operations.PublicOperations
{
    public class GetVendorServiceImageInput : OperationParameters
    {
       [Required]
        [Range(1, int.MaxValue)]
        public int RelationalId { get; set; }

        [Required]
        [Range(1,2)]
        public byte TypeId { get; set; }

        public int? ParentId { get; set; }
    }
    public class GetVendorServiceImageOutput
    {
        public List<VendorServiceImageDto> VendorServiceImages { get; set; } = new List<VendorServiceImageDto>();
    }
}
