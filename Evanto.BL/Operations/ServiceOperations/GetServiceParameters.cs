using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.ServiceOperations
{
    public class GetServiceInput : OperationParameters
    {
        public int? Id { get; set; }
        public bool? Status { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
    public class GetServiceOutput
    {
        public List<ServiceDto> Services { get; set; }
    }
}
