using System.ComponentModel.DataAnnotations;
using Evanto.Resources.Operations.UserType.Create;

namespace Evanto.BL.Operations.UserTypeOperations
{
   
    public class CreateUserTypeInput : OperationParameters
    {
        [Required(ErrorMessageResourceName = "IdIsRequired", ErrorMessageResourceType = typeof(CreateUserTypeResource))]
        [Range(1,int.MaxValue, ErrorMessageResourceName = "UserTypeIdRange", ErrorMessageResourceType = typeof(CreateUserTypeResource))]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName ="NameIsRequired", ErrorMessageResourceType = typeof(CreateUserTypeResource))]
        [MaxLength(20, ErrorMessageResourceName = "NameLenghtOverThan20", ErrorMessageResourceType = typeof(CreateUserTypeResource))]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessageResourceName = "DescriptionLenghtOverThan50", ErrorMessageResourceType = typeof(CreateUserTypeResource))]
        public string Description { get; set; }

        public bool Status { get; set; }
    }

    public class CreateUserTypeOutput
    {
        public bool IsCreated { get; set; }
    }
}
