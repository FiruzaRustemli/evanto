using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.EventTypeOperations
{
    public class GetEventTypeByUserOperation : Operation<GetEventTypeByUserInput, GetEventTypeByUserOutput>
    {
        public override void DoExecute()
        {
            this.Parameters = this.Parameters ?? new GetEventTypeByUserInput();

            GetEventTypeByUserOutput output = new GetEventTypeByUserOutput {EventTypes = new List<EventTypeUserDto>()};

            var predicate = PredicateBuilder.True<EventType>();

            if (this.Parameters.Id != null)
            {
                predicate = predicate.And(f => f.Id == this.Parameters.Id);
            }
            if (this.Parameters.Name != null)
            {
                predicate = predicate.And(f => f.Name == this.Parameters.Name);
            }

            predicate = predicate.And(f => f.Status);

            var eventTypes = this.Uow.GetRepository<EventType>().GetAll(predicate).ToList();
            
            output.EventTypes = Mapper.Map<List<EventType>, List<EventTypeUserDto>>(eventTypes);
            Result.Output = output;
        }
    }
}
