using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.User;
using Evanto.Resources.Operations.UserService.Create;

namespace Evanto.BL.Operations.UserServiceOperations
{
    public class CreateUserServiceByUserInput : OperationParameters
    {

        //[Required(ErrorMessageResourceName = "ServiceIdIsRequired", ErrorMessageResourceType = typeof(CreateUserServiceResource))]
        //[Range(1, int.MaxValue, ErrorMessageResourceName = "ServiceIdIsRange", ErrorMessageResourceType = typeof(CreateUserServiceResource))]
        public int ServiceId { get; set; }

        //[Required(ErrorMessageResourceName = "UserEventIdIsRequired", ErrorMessageResourceType = typeof(CreateUserServiceResource))]
        //[Range(1, int.MaxValue, ErrorMessageResourceName = "UserEventIdIsRange", ErrorMessageResourceType = typeof(CreateUserServiceResource))]
        public int UserEventId { get; set; }

        //[Required(ErrorMessageResourceName = "BudgetIsRequired", ErrorMessageResourceType = typeof(CreateUserServiceResource))]
        //public decimal Budget { get; set; }
    }   
    public class CreateUserServiceByUserOutput
    {
        public UserServiceUserDto UserService { get; set; }
    }
}
