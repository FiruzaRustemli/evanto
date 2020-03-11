using AutoMapper;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.DiscountCouponOperations
{
    public class CreateDiscountCouponOperation : Operation<CreateDiscountCouponInput, CreateDiscountCouponOutput>
    {
        #region Parameters
        #endregion

        #region Constructor
        #endregion

        #region Methods
        #endregion

        public override void DoExecute()
        {
            CreateDiscountCouponOutput output = new CreateDiscountCouponOutput();
            DiscountCoupon discountCoupon = Mapper.Map<CreateDiscountCouponInput, DiscountCoupon>(this.Parameters);
            this.Uow.GetRepository<DiscountCoupon>().Add(discountCoupon);
            this.Uow.SaveChanges();

            output.IsCreated = true;
            Result.Output = output;
        }
    }
}
