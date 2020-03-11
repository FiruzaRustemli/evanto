using System;
using System.ComponentModel.DataAnnotations;
using Evanto.Resources.Operations.UserActivation.Create;

namespace Evanto.BL.Operations.UserActivationOperations
{
    public class CreateUserActivationInput : OperationParameters
    {
        //[Required(ErrorMessageResourceName = "UserIdIsRequired", ErrorMessageResourceType = typeof(CreateUserActivationResource))]
        public int UserId { get; set; }

        //[Required(ErrorMessageResourceName = "CodeIsRequired", ErrorMessageResourceType = typeof(CreateUserActivationResource))]
        [StringLength(50)]
        public string Code { get; set; }

        public bool Status { get; set; }

        public DateTime ExpireDate { get; set; }

        public string Description { get; set; }

    }
    public class CreateUserActivationOutput
    {
        public bool IsCreated { get; set; } = false;
    }
}
