using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.ServicePeriodOperations
{
    public class GetServicePeriodOperation:Operation<GetServicePeriodInput,GetServicePeriodOutput>
    {
        public override void DoExecute()
        {
            GetServicePeriodOutput output = new GetServicePeriodOutput();
            var predicate = PredicateBuilder.True<DAL.Context.Period>();
            var periods = this.Uow.GetRepository<Period>().GetAll(predicate).ToList();
            output.Periods = Mapper.Map<List<Period>, List<PeriodDto>>(periods);
            foreach (var period in output.Periods)
            {
                period.NameAz = Uow.GetRepository<ResourceText>().GetAll().FirstOrDefault(x => x.LanguageId == 1 && x.Resource.ResourceKey == period.Name && x.Resource.Origin == "Period")?.Text;
                period.NameEn = Uow.GetRepository<ResourceText>().GetAll().FirstOrDefault(x => x.LanguageId == 2 && x.Resource.ResourceKey == period.Name && x.Resource.Origin == "Period")?.Text;
                period.NameRu = Uow.GetRepository<ResourceText>().GetAll().FirstOrDefault(x => x.LanguageId == 3 && x.Resource.ResourceKey == period.Name && x.Resource.Origin == "Period")?.Text;
            }
            Result.Output = output;
        }
    }
    

}
