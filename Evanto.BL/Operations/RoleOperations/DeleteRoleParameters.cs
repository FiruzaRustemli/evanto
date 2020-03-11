using System.ComponentModel.DataAnnotations;
using Evanto.Resources.Operations.Role.Create;

namespace Evanto.BL.Operations.RoleOperations
{
    public class DeleteRoleInput : OperationParameters
    {
        [Required(ErrorMessageResourceName = "IdIsRequired", ErrorMessageResourceType = typeof(CreateRoleResource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "RoleIdRange", ErrorMessageResourceType = typeof(CreateRoleResource))]
        public int Id { get; set; }


    }
    public class DeleteRoleOutput
    {
        public bool IsDeleted { get; set; } = false;
    }
}
