using System.Collections.Generic;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.UserStatusOperations
{
    public class GetUserStatusInput : OperationParameters
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class GetUserStatusOutput
    {
        public List<UserStatusDto> UserStatuses  { get; set; }
    }
}
