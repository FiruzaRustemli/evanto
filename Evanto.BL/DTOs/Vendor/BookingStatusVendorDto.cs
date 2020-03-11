using System;
using System.Collections.Generic;

namespace Evanto.BL.DTOs.Vendor
{
    public partial class BookingStatusVendorDto
    {
        
        public int Id { get; set; }

        
        public string Name { get; set; }

        
        public string Description { get; set; }

        
        public DateTime? CreatedDate { get; set; }

        
        public List<BookingVendorDto> Bookings { get; set; } = new List<BookingVendorDto>();
        
    }
}