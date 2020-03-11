using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.NotificationOperations
{
    public class GetBookingNotificationByVendorOperation : Operation<GetBookingNotificationByVendorInput, GetBookingNotificationByVendorOutput>
    {
        public override void DoExecute()
        {
            Parameters = Parameters ?? new  GetBookingNotificationByVendorInput();
            var output = new GetBookingNotificationByVendorOutput();
            if (Parameters.IsNew == 0)
            {
                output = new GetBookingNotificationByVendorOutput
                {
                    BookingNotifications = Mapper.Map<List<Notification>, List<BookingNotificationDto>>(
                    Uow.GetRepository<Notification>()
                        .GetAll(notification =>
                            notification.ReceiverId == Parameters.CurrentUserId
                            && notification.TypeId == (int)NotificationTypeValue.Booking)
                            .OrderByDescending(s => s.Id)
                            .Skip(Parameters.Skip)
                            .Take(10).ToList()),
                    UnreadCount = Uow.GetRepository<Notification>()
                        .GetAll(notification =>
                            notification.ReceiverId == Parameters.CurrentUserId
                            && notification.TypeId == (int)NotificationTypeValue.Booking
                            && notification.StatusId == 2)
                            .OrderByDescending(s => s.Id).Count()
                };
            }
            else if(Parameters.IsNew == 1)
            {
                output = new GetBookingNotificationByVendorOutput
                {
                    BookingNotifications = Mapper.Map<List<Notification>, List<BookingNotificationDto>>(
                    Uow.GetRepository<Notification>()
                        .GetAll(notification =>
                            notification.ReceiverId == Parameters.CurrentUserId
                            && notification.TypeId == (int)NotificationTypeValue.Booking
                            && notification.Id > Parameters.LastNotificationId)
                            .OrderByDescending(s => s.Id)
                            .Skip(Parameters.Skip).ToList())
                };
            }
            Result.Output = output;
        }
    }
}
