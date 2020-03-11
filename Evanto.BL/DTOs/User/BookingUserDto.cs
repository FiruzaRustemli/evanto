using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.BL.DTOs.Vendor;

namespace Evanto.BL.DTOs.User
{
    public class BookingUserDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int VendorId { get; set; }
        public int? UserServiceId { get; set; }
        public int StatusId { get; set; }
        public DateTime BookDate { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime? CreatedDate { get; set; }
        public  UserServiceForBookingUserDto UserService { get; set; }
        public  VendorUserDto Vendor { get; set; }
        public  BookingVendorServiceUserDto VendorService { get; set; }
    }
}
