using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.UserServiceOperations
{
    public class GetUserServiceByUserOperation : Operation<GetUserServiceByUserInput, GetUserServiceByUserOutput>
    {
        public override void DoExecute()
        {
            this.Parameters = Parameters ?? new GetUserServiceByUserInput();

            GetUserServiceByUserOutput output = new GetUserServiceByUserOutput();
            var userServices = this.Uow.EvantoContext.SearchUserService(
                    this.Parameters.Id,
                    this.Parameters.CurrentUserId,
                    this.Parameters.ServiceId,
                    this.Parameters.UserEventId,
                    null,
                    null
                )
                .Where(s => s.Status).ToList();


            //List<Booking> userServiceBookings = userServices.Select(userService => this.Uow.GetRepository<Booking>()
            //.GetAll(booking => booking.UserServiceId == userService.Id).FirstOrDefault()).ToList();


            output.UserServices = Mapper.Map<List<UserService>, List<UserServiceUserDto>>(userServices.Where(u => !u.Booking.Any()).ToList());
            output.UsedUserServices = Mapper.Map<List<UserService>, List<UserServiceUserDto>>(userServices.Where(u => u.Booking.Any()).ToList());
            Result.Output = output;
        }
    }
}
