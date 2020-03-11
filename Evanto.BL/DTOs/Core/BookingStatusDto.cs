using System;
using System.Collections.Generic;

namespace Evanto.BL.DTOs.Core
{
    public partial class BookingStatusDto
    {
        
        public int Id { get; set; }

        
        public string Name { get; set; }

        
        public string Description { get; set; }

        
        public DateTime? CreatedDate { get; set; }

        
        public List<BookingDto> Bookings { get; set; } = new List<BookingDto>();
        
    }
}