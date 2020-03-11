using System;
using System.Collections.Generic;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;

namespace Evanto.BL.Operations.UserOperations
{
    public class GetUserByUserInput : OperationParameters
    {
    }
    public class GetUserOutputByUser
    {
        public UserUserDto User { get; set; }
    }
}
