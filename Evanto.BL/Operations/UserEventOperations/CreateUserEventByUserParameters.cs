using System;
using System.ComponentModel.DataAnnotations;
using Evanto.Resources.Operations.UserEventOperation.Create;

namespace Evanto.BL.Operations.UserEventOperations
{
    public class CreateUserEventByUserInput : OperationParameters
    {
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "EventIdIsRequired", ErrorMessageResourceType = typeof(CreateUserEventResource))]
        public int EventId { get; set; }

       // [Required(ErrorMessageResourceName = "BudgetIsRequired", ErrorMessageResourceType = typeof(CreateUserEventResource))]
        public decimal? Budget { get; set; }

        [Required(ErrorMessageResourceName = "EventDateIsRequired", ErrorMessageResourceType = typeof(CreateUserEventResource))]
        public DateTime EventDate { get; set; }
    }
    public class CreateUserEventByUserOutput
    {
        public int Id { get; set; }
    }
}
