using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.UserOperations
{
    public class ChangeStatusUserInput : OperationParameters
    {
        [Required]
        public int Id { get; set; }

        public int StatusId { get; set; }
    }
    public class ChangeStatusUserOutput
    {
        public UserDto User { get; set; }
        public bool IsUpdated { get; set; } = false;
    } 
}
