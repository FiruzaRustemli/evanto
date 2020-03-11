using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.ServiceOperations
{
    public class UpdateServiceOperation : Operation<UpdateServiceInput, UpdateServiceOutput>
    {
        public override void DoExecute()
        {
            UpdateServiceOutput output = new UpdateServiceOutput();
            Service service = this.Uow.GetRepository<Service>().GetById(this.Parameters.Id);

            service.Description = this.Parameters.Description;
            service.Status = this.Parameters.Status;
            this.Uow.GetRepository<Service>().Update(service);

            var resource = Uow.GetRepository<Resource>().Get(x => x.ResourceKey == service.Name&& x.Origin=="Service");//todo read from app.config
            if (resource != null)
            {
                ResourceText resourceTextAz = Uow.GetRepository<ResourceText>().GetAll().FirstOrDefault(x => x.LanguageId == 1 && x.Resource.ResourceKey == service.Name && x.Resource.Origin == "Service");
                ResourceText resourceTextEn = Uow.GetRepository<ResourceText>().GetAll().FirstOrDefault(x => x.LanguageId == 2 && x.Resource.ResourceKey == service.Name && x.Resource.Origin == "Service");
                ResourceText resourceTextRu = Uow.GetRepository<ResourceText>().GetAll().FirstOrDefault(x => x.LanguageId == 3 && x.Resource.ResourceKey == service.Name && x.Resource.Origin == "Service");
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
                    Origin = "Service",
                    ResourceKey = service.Name
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
            Uow.GetRepository<Service>().Update(service);
            Uow.SaveChanges();
            output.Service = Mapper.Map<Service, ServiceDto>(service);
            output.IsUpdated = true;
            Result.Output = output;
        }
    }
}
