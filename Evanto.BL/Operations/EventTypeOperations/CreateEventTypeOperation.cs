using System.Collections.Generic;
using System.Linq;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.EventTypeOperations
{
    public class CreateEventTypeOperation : Operation<CreateEventTypeInput, CreateEventTypeOutput>
    {
        public override void DoExecute()
        {
            CreateEventTypeOutput typeOutput = new CreateEventTypeOutput();
            EventType eventModel = Mapper.Map<CreateEventTypeInput, EventType>(this.Parameters);
            eventModel.Name = Parameters.NameEn;
            this.Uow.GetRepository<EventType>().Add(eventModel);
            
            Resource eventResource = new Resource
            {
                Origin = "EventType",
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
            typeOutput.IsCreated = true;
            Result.Output = typeOutput;
        }
    }
}
