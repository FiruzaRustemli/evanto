using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.ServicePeriodPriceOperations
{
    public class GetServicePeriodPriceByAdminOperation:Operation<GetServicePeriodPriceByAdminInput,GetServicePeriodPriceByAdminOutput>
    {
        public override void DoExecute()
        {
            GetServicePeriodPriceByAdminOutput output = new GetServicePeriodPriceByAdminOutput();
            var predicate = PredicateBuilder.True<DAL.Context.ServicePeriodPrice>();
            var servicePeriodPrices = this.Uow.GetRepository<ServicePeriodPrice>().GetAll(predicate)
                .ToList();
            output.ServicePeriodPrices =
                Mapper.Map<List<ServicePeriodPrice>, List<ServicePeriodPriceDto>>(servicePeriodPrices);
            Result.Output = output;
        }
    }
    

}
