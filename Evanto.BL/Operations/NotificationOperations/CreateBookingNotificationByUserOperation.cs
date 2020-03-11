using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.BL.DTOs.User;
using Evanto.DAL.Context;
using Evanto.Utils;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.NotificationOperations
{
    public class CreateBookingNotificationByUserOperation : Operation<CreateBookingNotificationByUserInput, CreateBookingNotificationByUserOutput>
    {
        public override void DoExecute()
        {
            Notification notification = Mapper.Map<CreateBookingNotificationByUserInput, Notification>(this.Parameters);
            notification.TypeId = (byte)NotificationTypeValue.Booking;
            notification.StatusId = (byte)NotificationStatusValue.Unread;
            notification.SenderConsumerTypeId = (byte) NotificationConsumerTypeValue.User;
            notification.ReceiverConsumerTypeId = (byte) NotificationConsumerTypeValue.Vendor;
            notification.SenderId = Parameters.SenderId;

            Uow.GetRepository<Notification>().Add(notification);
            Uow.SaveChanges();

        }
    }
}
