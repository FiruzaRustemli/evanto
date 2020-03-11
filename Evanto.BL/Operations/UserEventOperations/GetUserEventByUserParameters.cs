using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;

namespace Evanto.BL.Operations.UserEventOperations
{
    public class GetUserEventByUserInput : OperationParameters
    {
        public int? Id { get; set; }
        public string SearchText { get; set; }
    }
    public class GetUserEventByUserOutput
    {
        public List<UserEventUserDto> UserEvents  { get; set; } = new List<UserEventUserDto>();
    }
}
