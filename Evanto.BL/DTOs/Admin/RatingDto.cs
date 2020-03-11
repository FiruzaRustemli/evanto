using System;

namespace Evanto.BL.DTOs.Admin
{
    public class RatingDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string VendorService { get; set; }
        public double Value { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Description { get; set; }
    }
}
