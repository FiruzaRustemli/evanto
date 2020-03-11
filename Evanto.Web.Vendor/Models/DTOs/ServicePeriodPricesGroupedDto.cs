using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.Web.Vendor.Models.DTOs
{
    public class ServicePeriodPricesGroupedDto
    {
        public int GroupById { get; set; }
        public string ServiceName { get; set; }
        public List<ServicePeriodPriceDto> ServicePeriodPrices { get; set; } = new List<ServicePeriodPriceDto>();
    }
}
