using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.NotificationOperations
{
    public class GetBookingNotificationByUserOperation : Operation<GetBookingNotificationByUserInput, GetBookingNotificationByUserOutput>
    {
        public override void DoExecute()
        {
            Parameters = Parameters ?? new GetBookingNotificationByUserInput();

            var output = new GetBookingNotificationByUserOutput
            {
                BookingNotifications = Mapper.Map<List<Notification>, List<BookingNotificationDto>>(
                    Uow.GetRepository<Notification>()
                        .GetAll(notification =>
                            notification.ReceiverId == Parameters.CurrentUserId
                            && notification.TypeId == (int) NotificationTypeValue.Booking)
                            .OrderByDescending(notification => notification.CreatedDate)
                            .ToList())
            };
            Result.Output = output;
        }
    }
}
