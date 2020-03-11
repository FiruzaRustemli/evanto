using System.ComponentModel.DataAnnotations;
using Evanto.Resources.Operations.Role.Create;

namespace Evanto.BL.Operations.RoleOperations
{
    public class CreateRoleInput : OperationParameters
    {
        [Required(ErrorMessageResourceName = "IdIsRequired", ErrorMessageResourceType = typeof(CreateRoleResource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "RoleIdRange", ErrorMessageResourceType = typeof(CreateRoleResource))]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "NameIsRequired", ErrorMessageResourceType = typeof(CreateRoleResource))]
        [MaxLength(20, ErrorMessageResourceName = "NameLenghtOverThan20", ErrorMessageResourceType = typeof(CreateRoleResource))]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessageResourceName = "DescriptionLenghtOverThan50", ErrorMessageResourceType = typeof(CreateRoleResource))]
        public string Description { get; set; }

        public bool Status { get; set; }
    }
    public class CreateRoleOutput
    {
        public bool IsCreated { get; set; } = false;
    }
}
