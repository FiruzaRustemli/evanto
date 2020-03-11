using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.Core
{
    public class BookingNotificationDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AdditionalData { get; set; }
    }
}
