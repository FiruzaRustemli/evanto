using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Evanto.Resources.Operations.UserStatus.Get;

namespace Evanto.BL.Operations.UserTypeOperations
{
    public class GetUserTypeInput:OperationParameters
    {
        [Required(ErrorMessageResourceName = "IdIsRequired", ErrorMessageResourceType = typeof(GetUserStatusResource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "UserStatusIdRange", ErrorMessageResourceType = typeof(GetUserStatusResource))]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "NameIsRequired", ErrorMessageResourceType = typeof(GetUserStatusResource))]
        [MaxLength(20, ErrorMessageResourceName = "NameLenghtOverThan20", ErrorMessageResourceType = typeof(GetUserStatusResource))]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessageResourceName = "DescriptionLenghtOverThan50", ErrorMessageResourceType = typeof(GetUserStatusResource))]
        public string Description { get; set; }

        public bool Status { get; set; }
    }

    public class GetUserTypeOutput
    {
        public List<UserTypeDto> UserTypes { get; set; }
    }
}
