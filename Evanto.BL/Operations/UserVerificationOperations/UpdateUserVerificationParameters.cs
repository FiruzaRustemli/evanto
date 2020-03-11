using System;
using Evanto.BL.DTOs.Admin;

namespace Evanto.BL.Operations.UserVerificationOperations
{
  public class UpdateUserVerificationInput : OperationParameters
  {
    public int Id { get; set; }
    public bool IsVerified { get; set; }

    public DateTime ExpireDate { get; set; }

  }
  public class UpdateUserVerificationOutput
  {
    public UserVerificationAdminDto UserVerification { get; set; }
    public bool IsUpdated { get; set; } = false;
  }
}
