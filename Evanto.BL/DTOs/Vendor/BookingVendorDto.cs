using System;

namespace Evanto.BL.DTOs.Vendor
{
    public class BookingVendorDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? VendorId { get; set; }
        public int? UserServiceId { get; set; }
        public int StatusId { get; set; }
        public DateTime BookDate { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }

        public string UserFullName { get; set; }
        public string UserImagePath { get; set; }
        public string ServiceName { get; set; }
        public string PhoneNumber { get; set; }
    }
}