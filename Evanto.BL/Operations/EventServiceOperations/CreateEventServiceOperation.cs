using AutoMapper;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.EventServiceOperations
{
    public class CreateEventServiceOperation : Operation<CreateEventServicesInput, CreateEventServicesOutput>
    {

        public override void DoExecute()
        {
            CreateEventServicesOutput output = new CreateEventServicesOutput();
            EventService eventService = Mapper.Map<CreateEventServicesInput, EventService>(this.Parameters);
            this.Uow.GetRepository<EventService>().Add(eventService);
            this.Uow.SaveChanges();
            this.Uow.Dispose();
            output.IsCreated = true;
            Result.Output = output;
        }
    }
}
