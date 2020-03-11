using Evanto.BL.DTOs.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.NotificationOperations
{
    public class GetBookingNotificationByUserInput : OperationParameters
    {

    }

    public class GetBookingNotificationByUserOutput
    {
        public List<BookingNotificationDto> BookingNotifications { get; set; }
    }
}
