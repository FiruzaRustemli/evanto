using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.Web.Vendor.Models.DTOs
{
    public class BookingDto
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public int? VendorId { get; set; }
        public int? UserServiceId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? BookDate { get; set; }
        public DateTime? DeadLine { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime? CreatedTime { get; set; }
    }
}
