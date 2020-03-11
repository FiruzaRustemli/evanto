using System.Linq;
using Evanto.BL.Operations.VendorOperations;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.ServicePeriodPriceOperations
{
    public class CreateServicePeriodPriceOperation:Operation<CreateServicePeriodPriceInput,CreateServicePeriodPriceOutput>
    {
        public override void DoExecute()
        {
            CreateServicePeriodPriceOutput result= new CreateServicePeriodPriceOutput();
            ServicePeriodPrice PeriodPrice = Mapper.Map<CreateServicePeriodPriceInput, ServicePeriodPrice>(this.Parameters);
            var predicate = PredicateBuilder.True<ServicePeriodPrice>();
            if (this.Parameters == null)
            {
                this.Parameters = new CreateServicePeriodPriceInput();
            }
            
                predicate = predicate.And(v => v.PeriodId == this.Parameters.PeriodId);
                predicate = predicate.And(v => v.ServiceId == this.Parameters.ServiceId);
            var data = Uow.GetRepository<ServicePeriodPrice>().GetAll(predicate).ToList();
            if (data.Count==0)
            {
                this.Uow.GetRepository<ServicePeriodPrice>().Add(PeriodPrice);
            }
            else
            {
                data[0].Price = (decimal) Parameters.Price;
                this.Uow.GetRepository<ServicePeriodPrice>().Update(data[0]);
            }
            this.Uow.SaveChanges();
            result.IsCreated = true;
            Result.Output = result;
        }
    }
}
