using Evanto.BL.DTOs.Admin;

namespace Evanto.BL.Operations.UserOperations
{
    public class GetUserInputByAdmin : OperationParameters
    {
        public int Id { get; set; }
    }
    public class GetUserOutputByAdmin
    {
        public UserAdminDto User { get; set; }
    }
}
