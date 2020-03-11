using Evanto.Web.Vendor.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evanto.Web.Vendor.Models.ViewModels
{
    public class ServicePeriodPriceGroupedDto
    {
        public int? GroupById { get; set; }
        public List<ServicePeriodPriceDto> ServicePeriodPrices { get; set; }
    }
}