using Evanto.DAL.Context;
using Evanto.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.VendorOperations
{
    public class CheckEmailAndPhoneOperation : Operation<CheckEmailAndPhoneInput, CheckEmailAndPhoneOutput>
    {
        public override void DoExecute()
        {
            if(Uow.GetRepository<User>().GetAll().Any(user => user.Username == Parameters.Email))
            {
                Result.ErrorList.Add(new Utils.Error
                {
                    Type = OperationResultCode.Validation,
                    Text = "This email already exist in the system",
                    Code = "AlreadyExistEmail"
                });
            }
            if (Uow.GetRepository<User>().GetAll().Any(user => user.Phone == Parameters.Phone))
            {
                Result.ErrorList.Add(new Utils.Error
                {
                    Type = OperationResultCode.Validation,
                    Text = "This phone number already exist in the system",
                    Code = "AlreadyExistPhone"
                });
            }
        }
    }
}
