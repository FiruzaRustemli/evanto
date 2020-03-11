using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.DAL.Context;
using Evanto.Utils;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.UserOperations
{
  public class VerifyPhoneOperation : Operation<VerifyPhoneInput, VerifyPhoneOutput>
  {
    public override void DoExecute()
    {
      var user = Uow.GetRepository<User>().GetAll(u => u.Id == Parameters.UserId).FirstOrDefault();

      if (user == null)
      {
        // Set error
        Result.ErrorList.Add(new Error()
        {
          Type = OperationResultCode.Validation,
          Code = "UserNotExists",
          Text = "User does not exist"
        });

        // Return
        return;
      }

      //change Phoneverified and update
      user.PhoneVerified = Parameters.Status;
      Uow.GetRepository<User>().Update(user);

      //get this user's Verifications which type is phone
      var verifications = Uow.GetRepository<UserVerification>().GetAll(u => u.UserId == Parameters.UserId&&u.VerificationTypeId==2).ToList();//TODO set type from enum

      //Chanfe isverified and update
      foreach (var  item in verifications)
      {
        item.IsVerified = true;
        Uow.GetRepository<UserVerification>().Update(item);
      }
      Uow.SaveChanges();
    }
  }
}
