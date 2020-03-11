using System;
using System.ComponentModel.DataAnnotations;
using Evanto.Resources.Operations.UserEventOperation.Create;

namespace Evanto.BL.Operations.UserEventOperations
{
    public class CreateUserEventInput : OperationParameters
    {
      //  [Required(ErrorMessageResourceName ="UserIdIsRequired", ErrorMessageResourceType = typeof(CreateUserEventResource))]
        public int UserId { get; set; }
       // [Required(ErrorMessageResourceName = "EventIdIsRequired", ErrorMessageResourceType = typeof(CreateUserEventResource))]
        public int EventId { get; set; }
       // [Required(ErrorMessageResourceName = "StatusIsRequired", ErrorMessageResourceType = typeof(CreateUserEventResource))]
        public bool Status { get; set; }
       // [Required(ErrorMessageResourceName = "BudgetIsRequired", ErrorMessageResourceType = typeof(CreateUserEventResource))]
        public decimal? Budget { get; set; }
       // [Required(ErrorMessageResourceName = "EventDateIsRequired", ErrorMessageResourceType = typeof(CreateUserEventResource))]
        public DateTime EventDate { get; set; }
    }
    public class CreateUserEventOutput
    {
        public bool IsCreated { get; set; } = false;
    }
}
