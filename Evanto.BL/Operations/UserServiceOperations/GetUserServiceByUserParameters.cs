using System;
using System.Collections.Generic;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;

namespace Evanto.BL.Operations.UserServiceOperations
{
    public class GetUserServiceByUserInput : OperationParameters
    {
        public int? Id { get; set; }
        public int? ServiceId { get; set; }
        public int? UserEventId { get; set; }
    }
    public class GetUserServiceByUserOutput
    {
        public List<UserServiceUserDto> UserServices { get; set; } = new List<UserServiceUserDto>();
        public List<UserServiceUserDto> UsedUserServices { get; set; } = new List<UserServiceUserDto>();
    }
}
