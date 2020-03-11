using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;
using Evanto.BL.DTOs.Vendor;

namespace Evanto.BL.Operations.VendorServiceOperations
{
    public class GetVendorServiceByVendorOperation : Operation<GetVendorServiceByVendorInput, GetVendorServiceByVendorOutput>
    {
        public override void DoExecute()
        {
            GetVendorServiceByVendorOutput output = new GetVendorServiceByVendorOutput {VendorServices = new List<VendorServiceVendorDto>()};
            var predicate = PredicateBuilder.True<VendorService>();

            if(this.Parameters.Id != null)
            {
                predicate = predicate.And(v => v.Id == this.Parameters.Id);
            }
            if (this.Parameters.ServicePeriodPriceId != null)
            {
                predicate = predicate.And(v => v.ServicePeriodPriceId == this.Parameters.ServicePeriodPriceId);
            }
            if (this.Parameters.VendorServicePacketId != null && this.Parameters.VendorServicePacketId != 0)
            {
                predicate = predicate.And(v => v.VendorServicePacketId == this.Parameters.VendorServicePacketId);
            }
                predicate = predicate.And(v => v.VendorServicePacket.VendorId == this.Parameters.CurrentUserId);
    
            if (this.Parameters.ServiceId != null)
            {
                predicate = predicate.And(v => v.ServicePeriodPrice.ServiceId == this.Parameters.ServiceId);
            }
            if (this.Parameters.ServiceIds.Count > 0)
            {
                predicate = predicate.And(v => this.Parameters.ServiceIds.Contains(v.ServicePeriodPrice.ServiceId));
            }

            List<VendorService> vendorServices = this.Uow.GetRepository<VendorService>().GetAll(predicate).OrderByDescending(s => s.Id).ToList();
            output.VendorServices = Mapper.Map<List<VendorService>, List<VendorServiceVendorDto>>(vendorServices);
            Result.Output = output;
        }
    }
}
