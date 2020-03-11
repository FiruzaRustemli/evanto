using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Evanto.Resources.Operations.Role.Create;

namespace Evanto.BL.Operations.RoleOperations
{
    public class UpdateRoleInput : OperationParameters
    {
        [Required(ErrorMessageResourceName = "IdIsRequired", ErrorMessageResourceType = typeof(CreateRoleResource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "RoleIdRange", ErrorMessageResourceType = typeof(CreateRoleResource))]
        public int Id { get; set; }

        public int OldId { get; set; }

        [Required(ErrorMessageResourceName = "NameIsRequired", ErrorMessageResourceType = typeof(CreateRoleResource))]
        [MaxLength(20, ErrorMessageResourceName = "NameLenghtOverThan20", ErrorMessageResourceType = typeof(CreateRoleResource))]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessageResourceName = "DescriptionLenghtOverThan50", ErrorMessageResourceType = typeof(CreateRoleResource))]
        public string Description { get; set; }

        public bool Status { get; set; } = false;
    }
    public class UpdateRoleOutput
    {
        public RoleDto Role { get; set; }
        public bool IsUpdated { get; set; } = false;
    }
}
