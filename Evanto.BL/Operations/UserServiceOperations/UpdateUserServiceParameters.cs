using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Evanto.Resources.Operations.UserService.Update;

namespace Evanto.BL.Operations.UserServiceOperations
{
    public class UpdateUserServiceInput: OperationParameters
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "ServiceIdIsRequired", ErrorMessageResourceType = typeof(UpdateUserServiceResource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "ServiceIdIsRange", ErrorMessageResourceType = typeof(UpdateUserServiceResource))]
        public int ServiceId { get; set; }

        [Required(ErrorMessageResourceName = "UserEventIdIsRequired", ErrorMessageResourceType = typeof(UpdateUserServiceResource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "UserEventIdIsRange", ErrorMessageResourceType = typeof(UpdateUserServiceResource))]
        public int UserEventId { get; set; }

        [Required(ErrorMessageResourceName = "StatusIsRequired", ErrorMessageResourceType = typeof(UpdateUserServiceResource))]
        public bool Status { get; set; }

        //[Required(ErrorMessageResourceName = "BudgetIsRequired", ErrorMessageResourceType = typeof(UpdateUserServiceResource))]
        //public decimal Budget { get; set; }
    }
    public class UpdateUserServiceOutput
    {
        public bool IsUpdated { get; set; } = false;
    }
}
