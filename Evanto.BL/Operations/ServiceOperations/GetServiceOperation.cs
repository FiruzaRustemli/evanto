using System;
using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.ServiceOperations
{
    public class GetServiceOperation : Operation<GetServiceInput, GetServiceOutput>
    {
        public override void DoExecute()
        {
            GetServiceOutput output = new GetServiceOutput { Services = new List<ServiceDto>() };
            var predicate = PredicateBuilder.True<Service>();

            if (this.Parameters.Id != null)
            {
                predicate = predicate.And(d => d.Id == this.Parameters.Id);
            }
            if (!String.IsNullOrEmpty(this.Parameters.Name))
            {
                predicate = predicate.And(d => d.Name == this.Parameters.Name);
            }
            if (this.Parameters.Status != null)
            {
                predicate = predicate.And(d => d.Status == this.Parameters.Status);
            }
            var services = this.Uow.GetRepository<Service>().GetAll(predicate).ToList();

            output.Services = Mapper.Map<List<Service>, List<ServiceDto>>(services);
            foreach (var service in output.Services)
            {
                service.NameAz = Uow.GetRepository<ResourceText>().GetAll().FirstOrDefault(x => x.LanguageId == 1 && x.Resource.ResourceKey == service.Name && x.Resource.Origin == "Service")?.Text;
                service.NameEn = Uow.GetRepository<ResourceText>().GetAll().FirstOrDefault(x => x.LanguageId == 2 && x.Resource.ResourceKey == service.Name && x.Resource.Origin == "Service")?.Text;
                service.NameRu = Uow.GetRepository<ResourceText>().GetAll().FirstOrDefault(x => x.LanguageId == 3 && x.Resource.ResourceKey == service.Name && x.Resource.Origin == "Service")?.Text;
            }
            Result.Output = output;
        }
    }
}
