using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.UserOperations
{
    public class ChangePasswordUserInput : OperationParameters
    {
        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
    public class ChangePasswordUserOutput
    {

    } 
}
