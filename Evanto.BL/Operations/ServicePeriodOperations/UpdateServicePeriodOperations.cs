using Evanto.DAL.Context;
using System.Linq;
using Evanto.BL.DTOs.Core;

namespace Evanto.BL.Operations.ServicePeriodOperations
{
    public class UpdateServicePeriodOperations : Operation<UpdateServicePeriodInput, UpdateServicePeriodOutput>
    {
        public override void DoExecute()
        {
            UpdateServicePeriodOutput result = new UpdateServicePeriodOutput();
            Period period = Uow.GetRepository<Period>().GetById(this.Parameters.Id);
            period.Duration = Parameters.Duration;
            period.Description = Parameters.Description;
            
            this.Uow.GetRepository<Period>().Update(period);
            var resource = Uow.GetRepository<Resource>().Get(x => x.ResourceKey == period.Name && x.Origin == "Period");//Todo
            if (resource != null)
            {
                ResourceText resourceTextAz = Uow.GetRepository<ResourceText>().GetAll().FirstOrDefault(x => x.LanguageId == 1 && x.Resource.ResourceKey == period.Name && x.Resource.Origin == "Period");
                ResourceText resourceTextEn = Uow.GetRepository<ResourceText>().GetAll().FirstOrDefault(x => x.LanguageId == 2 && x.Resource.ResourceKey == period.Name && x.Resource.Origin == "Period");
                ResourceText resourceTextRu = Uow.GetRepository<ResourceText>().GetAll().FirstOrDefault(x => x.LanguageId == 3 && x.Resource.ResourceKey == period.Name && x.Resource.Origin == "Period");
                if (resourceTextAz != null)
                {
                    resourceTextAz.Text = Parameters.NameAz;

                    Uow.GetRepository<ResourceText>().Update(resourceTextAz);
                }
                else
                {
                    resourceTextAz = new ResourceText
                    {
                        Text = Parameters.NameAz,
                        LanguageId = 1,//TODO read from enum
                        ResourceId = resource.Id
                    };

                    Uow.GetRepository<ResourceText>().Add(resourceTextAz);
                }

                if (resourceTextEn != null)
                {
                    resourceTextEn.Text = Parameters.NameEn;
                    Uow.GetRepository<ResourceText>().Update(resourceTextEn);
                }
                else
                {
                    resourceTextEn = new ResourceText
                    {
                        Text = Parameters.NameEn,
                        LanguageId = 2,//TODO read from enum
                        ResourceId = resource.Id
                    };

                    Uow.GetRepository<ResourceText>().Add(resourceTextEn);
                }

                if (resourceTextRu != null)
                {
                    resourceTextRu.Text = Parameters.NameRu;
                    Uow.GetRepository<ResourceText>().Update(resourceTextRu);
                }
                else
                {
                    resourceTextRu = new ResourceText
                    {
                        Text = Parameters.NameRu,
                        LanguageId = 3,//TODO read from enum
                        ResourceId = resource.Id
                    };

                    Uow.GetRepository<ResourceText>().Add(resourceTextRu);
                }

            }
            else
            {
                resource = new Resource
                {
                    Origin = "Period",
                    ResourceKey = period.Name
                };
                Uow.GetRepository<Resource>().Add(resource);

                Uow.SaveChanges();

                ResourceText resourceTextAz = new ResourceText
                {
                    Text = Parameters.NameAz,
                    LanguageId = 1,//TODO read from enum
                    ResourceId = resource.Id
                };

                ResourceText resourceTextEn = new ResourceText
                {
                    Text = Parameters.NameEn,
                    LanguageId = 2,//TODO read from enum
                    ResourceId = resource.Id
                };

                ResourceText resourceTextRu = new ResourceText
                {
                    Text = Parameters.NameRu,
                    LanguageId = 3,//TODO read from enum
                    ResourceId = resource.Id
                };


                Uow.GetRepository<ResourceText>().Add(resourceTextAz);
                Uow.GetRepository<ResourceText>().Add(resourceTextEn);
                Uow.GetRepository<ResourceText>().Add(resourceTextRu);
            }
            Uow.GetRepository<Period>().Update(period);
            this.Uow.SaveChanges();
            result.Period = Mapper.Map<Period,PeriodDto>(period);
            result.IsUpdated = true;
            Result.Output = result;
        }
    }
}
