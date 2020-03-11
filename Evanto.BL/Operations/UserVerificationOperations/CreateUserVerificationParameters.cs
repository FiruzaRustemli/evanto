using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.UserVerificationOperations
{
    public class CreateUserVerificationInput : OperationParameters
    {
        public int UserId { get; set; }
        public int VerificationTypeId { get; set; }
       // public int currentUserId { get; set; }
        public string VerificationCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime ExpireDate { get; set; }
    }

    public class CreateUserVerificationOutput
    {

    }
}
