using System.Collections.Generic;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.RoleOperations
{
    public class GetRoleInput : OperationParameters
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; } 
    }
    public class GetRoleOutput
    {
        public List<RoleDto> Roles { get; set; }
    }
}
