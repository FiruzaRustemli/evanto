using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;
using Evanto.DAL.Context;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.UserOperations
{
    public class GetEventAndBookingsCountByUserOperation : Operation<GetEventAndBookingsCountByUserInput, GetEventAndBookingsCountByUserOutput>
    {
        public override void DoExecute()
        {
            {
                GetEventAndBookingsCountByUserOutput output = new GetEventAndBookingsCountByUserOutput
                {
                    EventsCount = this.Uow.GetRepository<UserEvent>().GetAll(e => e.Status && e.UserId == this.Parameters.CurrentUserId).Count(),
                    ConfirmedBookingsCount =
                        this.Uow.GetRepository<Booking>()
                            .GetAll()
                            .Count(
                                b =>
                                    b.UserId == this.Parameters.CurrentUserId &&
                                    b.StatusId == (int)BookingStatusValue.Approved),
                    RejectedBookingsCount =
                        this.Uow.GetRepository<Booking>()
                            .GetAll()
                            .Count(
                                b =>
                                    b.UserId == this.Parameters.CurrentUserId &&
                                    b.StatusId == (int)BookingStatusValue.Rejected),
                    WaitingBookingsCount = this.Uow.GetRepository<Booking>().GetAll().Count(b => b.UserId == this.Parameters.CurrentUserId && b.StatusId == (int)BookingStatusValue.Waiting)

                };

                Result.Output = output;
            }
        }
    }
}
