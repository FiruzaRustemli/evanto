using System;
using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Evanto.Resources.Operations.UserActivation.Update;

namespace Evanto.BL.Operations.UserActivationOperations
{
  public class UpdateUserActivationInput : OperationParameters
  {
    public int Id { get; set; }
    public bool Status { get; set; }

    public DateTime ExpireDate { get; set; }

  }
  public class UpdateUserActivationOutput
  {
    public UserActivationDto UserActivation { get; set; }
    public bool IsUpdated { get; set; } = false;
  }
}
