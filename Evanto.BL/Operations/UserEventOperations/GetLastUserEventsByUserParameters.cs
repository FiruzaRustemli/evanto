using System;
using System.Collections.Generic;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;

namespace Evanto.BL.Operations.UserEventOperations
{
    public class GetLastUserEventsByUserInput : OperationParameters
    {
    }
    public class GetLastUserEventsByUserOutput
    {
        public List<UserEventUserDto> UserEvents  { get; set; } = new List<UserEventUserDto>();
    }
}
