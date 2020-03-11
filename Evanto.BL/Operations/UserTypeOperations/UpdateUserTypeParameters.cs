using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Evanto.Resources.Operations.UserStatus.Create;

namespace Evanto.BL.Operations.UserTypeOperations
{
    public class UpdateUserTypeInput:OperationParameters
    {
        [Required(ErrorMessageResourceName = "IdIsRequired", ErrorMessageResourceType = typeof(CreateUserStatusResource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "UserStatusIdRange", ErrorMessageResourceType = typeof(CreateUserStatusResource))]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "NameIsRequired", ErrorMessageResourceType = typeof(CreateUserStatusResource))]
        [MaxLength(20, ErrorMessageResourceName = "NameLenghtOverThan20", ErrorMessageResourceType = typeof(CreateUserStatusResource))]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessageResourceName = "DescriptionLenghtOverThan50", ErrorMessageResourceType = typeof(CreateUserStatusResource))]
        public string Description { get; set; }

        public bool Status { get; set; }
    }

    public class UpdateUserTypeOutput
    {
        public UserTypeDto UserType { get; set; }
        public bool IsEdited { get; set; } = false;
    }
}
