using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.DiscountCouponStatusOperations
{
    public class GetDiscountCouponStatusOperation:Operation<GetDiscountCouponStatusInput,GetDiscountCouponStatusOutput>
    {
        public override void DoExecute()
        {
            GetDiscountCouponStatusOutput output = new GetDiscountCouponStatusOutput
            {
                DiscountCouponStatuses = new List<DiscountCouponStatusDto>()
            };
            var predicate = PredicateBuilder.True<DAL.Context.DiscountCouponStatus>();
            var discountCouponStatuses = this.Uow.GetRepository<DAL.Context.DiscountCouponStatus>().GetAll(predicate)
                .ToList();
            output.DiscountCouponStatuses = Mapper.Map<List<DiscountCouponStatus>, List<DiscountCouponStatusDto>>(discountCouponStatuses);
            Result.Output = output;
        }
    }
    

}
