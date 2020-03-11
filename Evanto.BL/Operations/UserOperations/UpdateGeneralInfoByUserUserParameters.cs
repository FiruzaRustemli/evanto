using System;
using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;

namespace Evanto.BL.Operations.UserOperations
{
    public class UpdateGeneralInfoByUserUserInput : OperationParameters
    {

        //[Required(ErrorMessageResourceName = "UserFirstnameRequired")]
        //[MaxLength(50, ErrorMessageResourceName = "UserFirstnameMaxlength")]
        //[MinLength(3, ErrorMessageResourceName = "UserFirstnameMinlength")]
        public string FirstName { get; set; }
        public string UserName { get; set; }

        //[Required(ErrorMessageResourceName = "UserLastnameRequired")]
        //[MaxLength(50, ErrorMessageResourceName = "UserLastnameMaxlength")]
        //[MinLength(3, ErrorMessageResourceName = "UserLastnameMinlength")]
        public string LastName { get; set; }


        //[Required(ErrorMessageResourceName = "UserPhoneRequired")]
        //[MaxLength(20, ErrorMessageResourceName = "UserPhoneMaxlength")]
        //[MinLength(7, ErrorMessageResourceName = "UserPhoneMinlength")]
        public string Phone { get; set; }

    }
    public class UpdateGeneralInfoByUserUserOutput
    {
        public UserUserDto User { get; set; }
    } 
}
