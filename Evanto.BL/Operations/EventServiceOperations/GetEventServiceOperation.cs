using System;
using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.EventServiceOperations
{
    public class GetEventServiceOperation : Operation<GetEventServiceInput, GetEventServiceOutput>
    {
        public override void DoExecute()
        {
            GetEventServiceOutput output = new GetEventServiceOutput();
            output.EventServices = new List<EventServiceDto>();
            var predicate = PredicateBuilder.True<EventService>();

            if(this.Parameters.Id != null)
            {
                predicate = predicate.And(d => d.Id == this.Parameters.Id);
            }
            if(this.Parameters.EventId != null)
            {
                predicate = predicate.And(d => d.EventId == this.Parameters.EventId);
            }
            if(this.Parameters.ServiceId != null)
            {
                predicate = predicate.And(d => d.ServiceId == this.Parameters.ServiceId);
            }
            if(this.Parameters.CreatedDate != DateTime.MinValue)
            {
                predicate = predicate.And(d => d.CreatedDate == this.Parameters.CreatedDate);
            }
            var eventServices = this.Uow.GetRepository<EventService>().GetAll(predicate).ToList();
            output.EventServices = Mapper.Map<List<EventService>, List<EventServiceDto>>(eventServices);   
            Result.Output = output;
        }
    }
}
