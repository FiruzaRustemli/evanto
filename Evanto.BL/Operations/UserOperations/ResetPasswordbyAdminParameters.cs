using System.ComponentModel.DataAnnotations;

namespace Evanto.BL.Operations.UserOperations
{
    public class ResetPasswordbyAdminUserInput : OperationParameters
    {
        [Required]
        public int Id { get; set; }

        public string NewPassword { get; set; }

        
        public string ConfirmPassword { get; set; }
    }
    public class ResetPasswordbyAdminUserOutput
    {
        public bool IsCreated { get; set; } = false;
    } 
}
