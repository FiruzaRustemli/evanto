using System.Collections.Generic;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.ServicePeriodOperations
{
    public class CreateServicePeriodOperations:Operation<CreateServicePeriodInput,CreateServicePeriodOutput>
    {
        public override void DoExecute()
        {
            CreateServicePeriodOutput result= new CreateServicePeriodOutput();
            Period period = Mapper.Map<CreateServicePeriodInput, Period>(this.Parameters);
            period.Name = Parameters.NameEn;
            this.Uow.GetRepository<Period>().Add(period);

            Resource eventResource = new Resource
            {
                Origin = "Period",
                ResourceKey = Parameters.NameEn
            };
            this.Uow.GetRepository<Resource>().Add(eventResource);



            List<ResourceText> eventResourceTexts = new List<ResourceText>
            {
                new ResourceText
                {
                    ResourceId = eventResource.Id,
                    LanguageId = 1,
                    Text = Parameters.NameAz
                },
                new ResourceText
                {
                    ResourceId = eventResource.Id,
                    LanguageId = 2,
                    Text = Parameters.NameEn
                },
                new ResourceText
                {
                    ResourceId = eventResource.Id,
                    LanguageId = 3,
                    Text = Parameters.NameRu
                }
            };

            this.Uow.GetRepository<ResourceText>().AddRange(eventResourceTexts);
            this.Uow.SaveChanges();
            result.IsCreated = true;
            Result.Output = result;
        }
    }
}
