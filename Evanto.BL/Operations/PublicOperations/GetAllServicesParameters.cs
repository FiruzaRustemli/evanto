using System.Collections.Generic;
using Evanto.BL.DTOs.Public;

namespace Evanto.BL.Operations.PublicOperations
{
    public class GetAllServicesInput : OperationParameters
    {
       
    }
    public class GetAllServicesOutput
    {
        public List<ServicePublicDto> Services { get; set; } = new List<ServicePublicDto>();
    }
}
