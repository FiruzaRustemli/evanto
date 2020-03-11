using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.DiscountTypeOperations
{
    public class GetDiscountTypeOperation:Operation<GetDiscountTypeInput,GetDiscountTypeOutput>
    {

        public override void DoExecute()
        {
            GetDiscountTypeOutput output = new GetDiscountTypeOutput();
            var predicate = PredicateBuilder.True<DAL.Context.DiscountType>();
            var discountTypes = this.Uow.GetRepository<DiscountType>().GetAll(predicate)
                .ToList();
            output.DiscountTypes = Mapper.Map<List<DiscountType>, List<DiscountTypeDto>>(discountTypes);
            Result.Output = output;
        }
    }
    

}
