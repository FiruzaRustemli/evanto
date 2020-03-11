using Evanto.DAL.Context;
using Evanto.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.Resources.Operations.DiscountCoupon.Calculate;

namespace Evanto.BL.Operations.DiscountCouponOperations
{
    public class CalculateTotalDiscountByVendorOperation : Operation<CalculateTotalDiscountByVendorInput, CalculateTotalDiscountByVendorOutput>
    {
        public override void DoExecute()
         {
            CalculateTotalDiscountByVendorOutput output = new CalculateTotalDiscountByVendorOutput();
            decimal totalMoney = 0;
            foreach (var item in this.Parameters.ServicePeriodPrices)
            {
                totalMoney += item.Price;
            }

            //checking coupon number
            var discountCoupon = Uow.GetRepository<DiscountCoupon>()
                .Get(d => d.CouponNumber == this.Parameters.CouponNumber);
            output.TotalMoney = totalMoney;
            if (discountCoupon == null)
            {
                output.ResultType = (int)InvalidDiscountType.NotFound;
                output.DiscountMessage = CalculateTotalDiscountResouce.InvalidCouponMessage;
            }
            else if (discountCoupon.StatusId != (int)DiscountCouponStatusValue.Available)
            {
                output.ResultType = (int)InvalidDiscountType.InvalidStatus;
                output.DiscountMessage = CalculateTotalDiscountResouce.InvalidCouponMessage;
            }
            else if (discountCoupon.ExpireDate <= DateTime.Now)
            {
                output.ResultType = (int)InvalidDiscountType.Expired;
                output.DiscountMessage = CalculateTotalDiscountResouce.ExpiredCouponMessage;
            }
            else
            {
                if (discountCoupon.DiscountTypeId == (int)Utils.Enums.DiscountType.Amount)
                {
                    totalMoney = totalMoney - discountCoupon.Quantity;
                }
                else
                {
                    totalMoney = totalMoney - (totalMoney * discountCoupon.Quantity / 100);
                }
                output.ResultType = (int)InvalidDiscountType.Valid;
                output.DiscountType = discountCoupon.DiscountTypeId;
                output.DiscountAmount = discountCoupon.Quantity;
                output.TotalMoney = totalMoney < 0 ? 0 : totalMoney;
            }
            Result.Output = output;
        }
    }
}
