using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.UserOperations
{
    public class ChangeEmailUserInput : OperationParameters
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "UserUsernameRequired")]
        [MaxLength(30, ErrorMessageResourceName = "UserUsernameMaxlength")]
        [MinLength(7, ErrorMessageResourceName = "UserUsernameMinlength")]
        public string Username { get; set; }
    }
    public class ChangeEmailUserOutput
    {
        public UserDto User { get; set; }
        public bool IsUpdated { get; set; } = false;
    } 
}
