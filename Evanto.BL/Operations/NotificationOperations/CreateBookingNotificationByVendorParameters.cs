using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.NotificationOperations
{
    public class CreateBookingNotificationByVendorInput: OperationParameters
    {
        [Range(1, int.MaxValue)]
        public int ReceiverId { get; set; }

        [Range(1, int.MaxValue)]
        public int SenderId { get; set; }

        [Required]
        public string AdditionalData { get; set; }
    }

    public class CreateBookingNotificationByVendorOutput
    {

    }
}
