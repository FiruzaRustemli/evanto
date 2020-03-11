using System.Collections.Generic;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.ServiceOperations
{
    public class CreateServiceOperation : Operation<CreateServiceInput, CreateServiceOutput>
    {
        public override void DoExecute()
        {
            CreateServiceOutput output = new CreateServiceOutput();
            Service service = Mapper.Map<CreateServiceInput, Service>(this.Parameters);
            service.Name = Parameters.NameEn;
            //add service to DB
            this.Uow.GetRepository<Service>().Add(service);

            //Created new resource for this service and added to db
            Resource eventResource = new Resource
            {
                Origin = "Service",
                ResourceKey = Parameters.NameEn
            };
            this.Uow.GetRepository<Resource>().Add(eventResource);

            //Created new resource text for this resource and added to DB
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
            output.IsCreated = true;
            Result.Output = output;
        }
    }
}
