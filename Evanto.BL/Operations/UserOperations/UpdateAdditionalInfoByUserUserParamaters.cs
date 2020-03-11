using System;
using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;

namespace Evanto.BL.Operations.UserOperations
{
    public class UpdateAdditionalInfoByUserUserInput : OperationParameters
    {

        [Range(1, int.MaxValue)]
        public int GenderId { get; set; }

        public int? MaritalStatus { get; set; }

        public DateTime? Birthday { get; set; }

    }
    public class UpdateAdditionalInfoByUserUserOutput
    {
        public UserUserDto User { get; set; }
    } 
}
