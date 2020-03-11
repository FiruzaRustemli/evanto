using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.CouponTypeOperations
{
    public class GetCouponTypeOperation:Operation<GetCouponTypeInput,GetCouponTypeOutput>
    {

        public override void DoExecute()
        {
            GetCouponTypeOutput output = new GetCouponTypeOutput();
            var predicate = PredicateBuilder.True<DAL.Context.CouponType>();
            var couponTypes = this.Uow.GetRepository<CouponType>().GetAll(predicate)
                .ToList();
            output.CouponTypes = Mapper.Map<List<CouponType>, List<CouponTypeDto>>(couponTypes);
            Result.Output = output;
        }
    }
    

}
