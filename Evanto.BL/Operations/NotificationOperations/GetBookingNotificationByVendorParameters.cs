using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.NotificationOperations
{
    public class GetBookingNotificationByVendorInput : OperationParameters
    {
        public int Skip { get; set; }
        public int IsNew { get; set; }
        public int LastNotificationId { get; set; }
    }
    public class GetBookingNotificationByVendorOutput
    {
        public List<BookingNotificationDto> BookingNotifications { get; set; }
        public int UnreadCount { get; set; }
    }
}
