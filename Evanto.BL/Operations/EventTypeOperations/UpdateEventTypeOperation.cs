using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.EventTypeOperations
{
    public class UpdateEventTypeOperation : Operation<UpdateEventInput, UpdateEventOutput>
    {
        public override void DoExecute()
        {
            UpdateEventOutput output = new UpdateEventOutput();
            EventType eventModel = Uow.GetRepository<EventType>().GetById(Parameters.Id);

            eventModel.Status = Parameters.Status;
            Uow.GetRepository<EventType>().Update(eventModel);

            var resource = Uow.GetRepository<Resource>().Get(x => x.ResourceKey == eventModel.Name && x.Origin == "EventType");
            if (resource != null)
            {
                ResourceText resourceTextAz = Uow.GetRepository<ResourceText>().GetAll().FirstOrDefault(x => x.LanguageId == 1 && x.Resource.ResourceKey == eventModel.Name && x.Resource.Origin == "EventType");
                ResourceText resourceTextEn = Uow.GetRepository<ResourceText>().GetAll().FirstOrDefault(x => x.LanguageId == 2 && x.Resource.ResourceKey == eventModel.Name && x.Resource.Origin == "EventType");
                ResourceText resourceTextRu = Uow.GetRepository<ResourceText>().GetAll().FirstOrDefault(x => x.LanguageId == 3 && x.Resource.ResourceKey == eventModel.Name && x.Resource.Origin == "EventType");
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
                    Origin = "EventType",
                    ResourceKey = eventModel.Name
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
            Uow.GetRepository<EventType>().Update(eventModel);
            Uow.SaveChanges();
            output.EventType = Mapper.Map<EventType, EventTypeDto>(eventModel);

            output.IsUpdated = true;
            Result.Output = output;
        }
    }
}
