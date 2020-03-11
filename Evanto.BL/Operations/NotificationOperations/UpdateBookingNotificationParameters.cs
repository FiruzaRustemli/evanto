using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.NotificationOperations
{
    public class UpdateBookingNotificationInput: OperationParameters
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }  
        [Range(0,1)]
        public byte StatusId { get; set; }
    }

    public class UpdateBookingNotificationOutput
    {
        public BookingNotificationDto BookingNotification { get; set; }
    }
}
