using System;
using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;
using Evanto.BL.Operations.UserServiceOperations;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.EventServiceOperations
{
    public class GetEventServiceByUserOperation : Operation<GetEventServiceByUserInput, GetEventServiceByUserOutput>
    {
        public override void DoExecute()
        {
            this.Parameters = Parameters ?? new GetEventServiceByUserInput();

            GetEventServiceByUserOutput output = new GetEventServiceByUserOutput();
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

            var eventServices = this.Uow.GetRepository<EventService>().GetAll(predicate).ToList();
            output.EventServices = Mapper.Map<List<EventService>, List<EventServiceUserDto>>(eventServices);   
            Result.Output = output;
        }
    }
}
