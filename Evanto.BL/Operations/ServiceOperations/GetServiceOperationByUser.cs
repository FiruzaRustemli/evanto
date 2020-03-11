using System;
using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.ServiceOperations
{
    public class GetServiceByUserOperation : Operation<GetServiceByUserInput, GetServiceByUserOutput>
    {
        public override void DoExecute()
        {
            this.Parameters = Parameters ?? new GetServiceByUserInput();

            GetServiceByUserOutput output = new GetServiceByUserOutput();
            var predicate = PredicateBuilder.True<Service>();

            if (this.Parameters.Id != null)
            {
                predicate = predicate.And(d => d.Id == this.Parameters.Id);
            }
            if (!string.IsNullOrEmpty(this.Parameters.Name))
            {
                predicate = predicate.And(d => d.Name == this.Parameters.Name);
            }

            predicate = predicate.And(d => d.Status);

            var services = this.Uow.GetRepository<Service>().GetAll(predicate).ToList();
            output.Services = Mapper.Map<List<Service>, List<ServiceUserDto>>(services);
            Result.Output = output;
        }
    }
}
