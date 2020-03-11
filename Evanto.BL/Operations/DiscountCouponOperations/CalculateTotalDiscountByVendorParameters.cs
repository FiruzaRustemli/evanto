using Evanto.BL.DTOs.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.DiscountCouponOperations
{
    public class CalculateTotalDiscountByVendorInput: OperationParameters
    {
        public List<ServicePeriodPriceVendorDto> ServicePeriodPrices { get; set; }
        public string CouponNumber { get; set; }
    }
    public class CalculateTotalDiscountByVendorOutput
    {
        public decimal TotalMoney { get; set; }

        public int DiscountAmount { get; set; }
        public int DiscountType { get; set; }
        public int ResultType { get; set; }
        public string DiscountMessage { get; set; }
    }
}
