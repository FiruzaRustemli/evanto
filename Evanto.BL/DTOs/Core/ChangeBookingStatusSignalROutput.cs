using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.Core
{
    public class ChangeBookingStatusSignalROutput
    {
        public int BookingId { get; set; }
        public int StatusId { get; set; }
    }
}
