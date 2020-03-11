using System;
using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Public;
using Evanto.BL.Operations.PaymentOperations;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.PublicOperations
{
    public class GetAllServicesOperation : Operation<GetAllServicesInput, GetAllServicesOutput>
    {
        public override void DoExecute()
        {
            this.Parameters = Parameters ?? new GetAllServicesInput();

            var services = this.Uow.GetRepository<Service>().GetAll().ToList();
            var output = new GetAllServicesOutput
            {
                Services = Mapper.Map<List<Service>, List<ServicePublicDto>>(services)
            };

            Result.Output = output;
        }
    }
}
