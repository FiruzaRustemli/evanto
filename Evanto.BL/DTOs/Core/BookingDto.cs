using System;

namespace Evanto.BL.DTOs.Core
{
    public class BookingDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int VendorId { get; set; }
        public int? UserServiceId { get; set; }

        
        public int StatusId { get; set; }

        
        public DateTime BookDate { get; set; }

        
        public DateTime Deadline { get; set; }

        
        public string Description { get; set; }

        
        public DateTime? CreatedDate { get; set; }

        
        public BookingStatusDto BookingStatus { get; set; }

        
        public UserDto User { get; set; }

        
        public UserServiceDto UserService { get; set; }
        public VendorDto Vendor { get; set; }
        
    }
}