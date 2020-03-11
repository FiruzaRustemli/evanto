using System;
using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Evanto.Resources.Operations.UserEventOperation.Update;

namespace Evanto.BL.Operations.UserEventOperations
{
    public class UpdateUserEventInput : OperationParameters
    {
        [Required(ErrorMessageResourceName = "IdIsRequired", ErrorMessageResourceType = typeof(UpdateUserEventResource))]
        public int Id { get; set; }
       
        [Required(ErrorMessageResourceName = "BudgetIsRequired", ErrorMessageResourceType = typeof(UpdateUserEventResource))]
        public decimal Budget { get; set; }
        [Required(ErrorMessageResourceName = "EventDateIsRequired", ErrorMessageResourceType = typeof(UpdateUserEventResource))]
        public DateTime EventDate { get; set; }
    }
    public class UpdateUserEventOutput
    {
        public UserEventDto UserEvent { get; set; }
        public bool IsUpdated { get; set; } = false;
    }
}
