using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.User
{
    public class BookingVendorServiceUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string ServiceName { get; set; }
        public int ServiceId { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
        public int? DailyQuantity { get; set; }
        public double? Rating { get; set; }
        public int RatedUserCount { get; set; }
    }
}
