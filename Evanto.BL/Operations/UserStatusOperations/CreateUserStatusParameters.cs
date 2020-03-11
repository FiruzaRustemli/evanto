using System.ComponentModel.DataAnnotations;
using Evanto.Resources.Operations.UserStatus.Create;

namespace Evanto.BL.Operations.UserStatusOperations
{
   
    public class CreateUserStatusInput : OperationParameters
    {
        [Required(ErrorMessageResourceName = "IdIsRequired", ErrorMessageResourceType = typeof(CreateUserStatusResource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "UserStatusIdRange", ErrorMessageResourceType = typeof(CreateUserStatusResource))]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "NameIsRequired", ErrorMessageResourceType = typeof(CreateUserStatusResource))]
        [MaxLength(20, ErrorMessageResourceName = "NameLenghtOverThan20", ErrorMessageResourceType = typeof(CreateUserStatusResource))]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessageResourceName = "DescriptionLenghtOverThan50", ErrorMessageResourceType = typeof(CreateUserStatusResource))]
        public string Description { get; set; }
        
    }

    public class CreateUserStatusOutput
    {
        public bool IsCreated { get; set; } = false;
    }
}
