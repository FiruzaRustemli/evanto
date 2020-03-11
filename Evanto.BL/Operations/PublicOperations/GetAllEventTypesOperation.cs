using System;
using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Public;
using Evanto.BL.Operations.PaymentOperations;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.PublicOperations
{
    public class GetAllEventTypesOperation : Operation<GetAllEventTypesInput, GetAllEventTypesOutput>
    {
        public override void DoExecute()
        {
            this.Parameters = Parameters ?? new GetAllEventTypesInput();

            var eventTypes = this.Uow.GetRepository<EventType>().GetAll().ToList();
            var output = new GetAllEventTypesOutput
            {
                 EventTypes = Mapper.Map<List<EventType>, List<EventTypePublicDto>>(eventTypes)
            };

            Result.Output = output;
        }
    }
}
