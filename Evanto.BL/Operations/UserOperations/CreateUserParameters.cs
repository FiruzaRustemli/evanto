using System;
using System.ComponentModel.DataAnnotations;

namespace Evanto.BL.Operations.UserOperations
{
    public class CreateUserInput : OperationParameters
    {
        //[Required(ErrorMessageResourceName = "UserFirstnameRequired")]
        //[MaxLength(50, ErrorMessageResourceName = "UserFirstnameMaxlength")]
        //[MinLength(3, ErrorMessageResourceName = "UserFirstnameMinlength")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        //[Required(ErrorMessageResourceName = "UserLastnameRequired")]
        //[MaxLength(50, ErrorMessageResourceName = "UserLastnameMaxlength")]
        //[MinLength(3, ErrorMessageResourceName = "UserLastnameMinlength")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        //[Required(ErrorMessageResourceName = "UserPhoneRequired")]
        //[MaxLength(20, ErrorMessageResourceName = "UserPhoneMaxlength")]
        //[MinLength(7, ErrorMessageResourceName = "UserPhoneMinlength")]
        [Required]
        [StringLength(20, MinimumLength = 7)]
        public string Phone { get; set; }

        //[Required(ErrorMessageResourceName = "UserUsernameRequired")]
        //[MaxLength(30, ErrorMessageResourceName = "UserUsernameMaxlength")]
        //[MinLength(7, ErrorMessageResourceName = "UserUsernameMinlength")]
        [Required]
        [EmailAddress]
        public string Username { get; set; }

        //[MaxLength(64)]
        //public byte[] Salt { get; set; }

        //[Required(ErrorMessageResourceName = "UserPasswordRequired")]
        //[MaxLength(64, ErrorMessageResourceName = "UserPasswordMaxlength")]
        //[MinLength(3, ErrorMessageResourceName = "UserPasswordMinlength")]
        [StringLength(64, MinimumLength = 3)]
        public string PasswordString { get; set; }

        [Range(1,2)]
        public byte GenderId { get; set; }

        [Range(1,2)]
        public byte VerificationTypeId { get; set; }

    }
    public class CreateUserOutput
    {
        public bool IsCreated { get; set; } = false;
        public int UserId { get; set; }
    } 
}
