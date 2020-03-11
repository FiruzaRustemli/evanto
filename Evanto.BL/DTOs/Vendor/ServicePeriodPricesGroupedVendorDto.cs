using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.DTOs.Vendor
{
    public class ServicePeriodPricesGroupedVendorDto
    {
        public int GroupById { get; set; }
        public string ServiceName { get; set; }
        public List<ServicePeriodPriceVendorDto> ServicePeriodPrices { get; set; } = new List<ServicePeriodPriceVendorDto>();
    }
}
