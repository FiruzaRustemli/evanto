using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;

namespace Evanto.BL.Operations.ServiceOperations
{
    public class GetServiceByUserInput : OperationParameters
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }
    public class GetServiceByUserOutput
    {
        public List<ServiceUserDto> Services { get; set; } = new List<ServiceUserDto>();
    }
}
