using Evanto.DAL.Context;
using Evanto.Utils;
using Evanto.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.NotificationOperations
{
    public class CreateBookingNotificationByVendorOperation : Operation<CreateBookingNotificationByVendorInput, CreateBookingNotificationByVendorOutput>
    {
        public override void DoExecute()
        {
            Notification notification = Mapper.Map<CreateBookingNotificationByVendorInput, Notification>(this.Parameters);
            notification.TypeId = (byte)NotificationTypeValue.Booking;
            notification.StatusId = (byte)NotificationStatusValue.Unread;
            notification.SenderConsumerTypeId = (byte)NotificationConsumerTypeValue.Vendor;
            notification.ReceiverConsumerTypeId = (byte)NotificationConsumerTypeValue.User;
            notification.SenderId = Parameters.SenderId;

            Uow.GetRepository<Notification>().Add(notification);
            Uow.SaveChanges();
        }
    }
}
