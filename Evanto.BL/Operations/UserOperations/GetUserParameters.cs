using System;
using System.Collections.Generic;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.UserOperations
{
    public class GetUserInput : OperationParameters
    {
        public int? Id { get; set; }
        public string Username { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int? MaritalStatus { get; set; }
        public DateTime? BirthDay { get; set; }
        public int? Type { get; set; }
    }
    public class GetUserOutput
    {
        public List<UserDto> Users { get; set; } = new List<UserDto>();
    }
}
