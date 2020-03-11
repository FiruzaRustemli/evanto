using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.User
{
    public class VendorServiceUserDto
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public string Photo { get; set; }

        public double? Rating { get; set; }
        public int RatedUserCount { get; set; }


        public decimal? PriceMin { get; set; }


        public decimal? PriceMax { get; set; }


        public int? DailyQuantity { get; set; }


        public string Description { get; set; }


        public DateTime CreatedDate { get; set; }


        public int ServicePeriodPriceId { get; set; }


        public int? DiscountCouponId { get; set; }


        public int VendorServicePacketId { get; set; }

        public VendorServicePacketUserDto VendorServicePacket { get; set; }

        public ServicePeriodPriceUserDto ServicePeriodPrice { get; set; }
    }
}
