using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.DiscountCouponOperations
{
    public class UpdateDiscountCouponOperation : Operation<UpdateDiscountCouponInput, UpdateDiscountCouponOutput>
    {
        #region Parameters
        #endregion

        #region Constructor
        #endregion

        #region Methods
        #endregion
        
        public override void DoExecute()
        {
            UpdateDiscountCouponOutput output = new UpdateDiscountCouponOutput();
            DiscountCoupon discountCoupon = this.Uow.GetRepository<DiscountCoupon>().GetById(this.Parameters.Id);
            discountCoupon.StatusId = this.Parameters.StatusId;
            discountCoupon.CouponTypeId = this.Parameters.CouponTypeId;
            discountCoupon.DiscountTypeId = this.Parameters.DiscountTypeId;
            discountCoupon.CouponNumber = this.Parameters.CouponNumber;
            discountCoupon.Quantity = this.Parameters.Quantity;
            discountCoupon.Description = this.Parameters.Description;

            this.Uow.GetRepository<DiscountCoupon>().Update(discountCoupon);
            this.Uow.SaveChanges();

            output.DiscountCoupon = Mapper.Map<DiscountCoupon, DiscountCouponDto>(discountCoupon);
            output.IsUpdated = true;
            Result.Output = output;
        }
    }
}
