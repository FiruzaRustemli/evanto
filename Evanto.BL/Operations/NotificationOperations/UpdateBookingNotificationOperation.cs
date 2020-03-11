using Evanto.DAL.Context;
using Evanto.Utils;
using Evanto.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.NotificationOperations
{
    public class UpdateBookingNotificationOperation : Operation<UpdateBookingNotificationInput, UpdateBookingNotificationOutput>
    {
        public override void DoExecute()
        {
            var output = new UpdateBookingNotificationOutput();
            var notification = Uow.GetRepository<Notification>().Get(n => 
                n.ReceiverId == Parameters.CurrentUserId 
                && n.Id == Parameters.Id);

            notification.StatusId = Parameters.StatusId;

            Uow.GetRepository<Notification>().Update(notification);
            Uow.SaveChanges();

            output.BookingNotification = Mapper.Map<Notification, BookingNotificationDto>(notification);
            Result.Output = output;
        }
    }
}
