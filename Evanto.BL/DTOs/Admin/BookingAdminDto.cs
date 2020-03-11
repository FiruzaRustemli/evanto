using System;

namespace Evanto.BL.DTOs.Admin
{
    public class BookingAdminDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }

        public int? VendorServiceId { get; set; }

        public UserAdminDto User { get; set; }

        public AdminVendorDto Vendor { get; set; }
       
        
        public int StatusId { get; set; }

        
        public DateTime BookDate { get; set; }

        
        public DateTime Deadline { get; set; }

        
        public string Description { get; set; }

        
        public DateTime? CreatedDate { get; set; }
    }
}