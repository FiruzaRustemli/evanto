using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.DiscountCouponOperations
{
    public class GetDiscountCouponOperation : Operation<GetDiscountCouponInput, GetDiscountCouponOutput>
    {
        public override void DoExecute()
        {
            GetDiscountCouponOutput output = new GetDiscountCouponOutput
            {
                DiscountCoupons = new List<DiscountCouponDto>()
            };
            var predicate = PredicateBuilder.True<DiscountCoupon>();
            if (this.Parameters.Id != null)
            {
                predicate = predicate.And(f => f.Id == this.Parameters.Id);
            }
            if (this.Parameters.CouponNumber != null)
            {
                predicate = predicate.And(f => f.CouponNumber == this.Parameters.CouponNumber);
            }
            if (this.Parameters.StatusId != null)
            {
                predicate = predicate.And(f => f.StatusId == this.Parameters.StatusId);
            }
            if (this.Parameters.CouponTypeId!=null)
            {
                predicate = predicate.And(f => f.CouponTypeId == this.Parameters.CouponTypeId);
            }
            if (this.Parameters.DiscountTypeId!=null)
            {
                predicate = predicate.And(f => f.DiscountTypeId == this.Parameters.DiscountTypeId);
            }
            
            if (this.Parameters.CreatedDate != DateTime.MinValue)
            {
                predicate = predicate.And(f => f.CreatedDate == this.Parameters.CreatedDate);
            }
            var discountCoupons = this.Uow.GetRepository<DiscountCoupon>().GetAll(predicate).ToList();
            output.DiscountCoupons = Mapper.Map<List<DiscountCoupon>, List<DiscountCouponDto>>(discountCoupons);
            Result.Output = output;
        }
    }
}
