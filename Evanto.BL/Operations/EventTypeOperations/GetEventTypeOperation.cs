using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.EventTypeOperations
{
    public class GetEventTypeOperation : Operation<GetEventTypeInput, GetEventTypeOutput>
    {
        public override void DoExecute()
        {
            this.Parameters = this.Parameters ?? new GetEventTypeInput();

            GetEventTypeOutput output = new GetEventTypeOutput {EventTypes = new List<EventTypeDto>()};

            var predicate = PredicateBuilder.True<EventType>();

            if (this.Parameters.Id != null)
            {
                predicate = predicate.And(f => f.Id == this.Parameters.Id);
            }
            if (this.Parameters.Name != null)
            {
                predicate = predicate.And(f => f.Name == this.Parameters.Name);
            }

            var eventTypes = this.Uow.GetRepository<EventType>().GetAll(predicate).ToList();
            
            output.EventTypes = Mapper.Map<List<EventType>, List<EventTypeDto>>(eventTypes);
            foreach (var type in output.EventTypes)
            {
                type.NameAz =Uow.GetRepository<ResourceText>().GetAll().FirstOrDefault(x => x.LanguageId == 1 && x.Resource.ResourceKey == type.Name && x.Resource.Origin == "EventType")?.Text;
                type.NameEn =Uow.GetRepository<ResourceText>().GetAll().FirstOrDefault(x => x.LanguageId == 2 && x.Resource.ResourceKey == type.Name && x.Resource.Origin == "EventType")?.Text;
                type.NameRu =Uow.GetRepository<ResourceText>().GetAll().FirstOrDefault(x => x.LanguageId == 3 && x.Resource.ResourceKey == type.Name && x.Resource.Origin == "EventType")?.Text;
            }
            Result.Output = output;
        }
    }
}
