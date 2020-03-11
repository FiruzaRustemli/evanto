using Evanto.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.VendorServiceOperations
{
    public class ChangeStatusVendorServiceByVendorOperation : Operation<ChangeStatusVendorServiceByVendorInput, ChangeStatusVendorServiceByVendorOutput>
    {
        public override void DoExecute()
        {
            ChangeStatusVendorServiceByVendorOutput output = new ChangeStatusVendorServiceByVendorOutput();
            var vendorService = Uow.GetRepository<VendorService>()
                .Get(vs => vs.Id == this.Parameters.VendorServiceId && vs.VendorServicePacket.VendorId == this.Parameters.CurrentUserId);

            vendorService.Status = this.Parameters.Status;
            Uow.GetRepository<VendorService>().Update(vendorService);
            Uow.SaveChanges();
            output.VendorServiceId = vendorService.Id;
            output.Status = vendorService.Status;
            output.IsUpdated = true;
            Result.Output = output;
        }
    }
}
