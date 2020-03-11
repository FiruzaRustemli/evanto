using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.UserOperations
{
    public class UserValidationInput : OperationParameters
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class UserValidationOutput : OperationParameters
    {
        public UserValidationDto User { get; set; }
    }
}

