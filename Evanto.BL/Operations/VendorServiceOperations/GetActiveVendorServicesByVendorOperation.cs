using Evanto.BL.DTOs.Vendor;
using Evanto.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.VendorServiceOperations
{
    public class GetActiveVendorServicesByVendorOperation : Operation<GetActiveVendorServicesByVendorInput, GetActiveVendorServicesByVendorOutput>
    {
        public override void DoExecute()
        {
            var output = new GetActiveVendorServicesByVendorOutput();
            var vendorServices = Uow.GetRepository<VendorService>()
                .GetAll(v => v.Status == true && v.VendorServicePacket.VendorId == this.Parameters.CurrentUserId)
                .ToList();
            output.VendorServices = Mapper.Map<List<VendorService>, List<VendorServiceVendorDto>>(vendorServices);
            Result.Output = output;
        }
    }
}
