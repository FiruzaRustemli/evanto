using Evanto.DAL.Context;

namespace Evanto.BL.Operations.ServicePeriodPriceOperations
{
    public class UpdateServicePeriodPriceOperation : Operation<UpdateServicePeriodPriceInput,UpdateServicePeriodPriceOutput>
    {
        public override void DoExecute()
        {
            UpdateServicePeriodPriceOutput result = new UpdateServicePeriodPriceOutput();
            ServicePeriodPrice servicePeriodPrice = Uow.GetRepository<ServicePeriodPrice>().GetById(this.Parameters.Id);
               servicePeriodPrice= Mapper.Map<UpdateServicePeriodPriceInput, ServicePeriodPrice>(this.Parameters,servicePeriodPrice);
            this.Uow.GetRepository<ServicePeriodPrice>().Update(servicePeriodPrice);
            this.Uow.SaveChanges();
            result.IsUpdated = true;
            Result.Output = result;
        }
    }
}
