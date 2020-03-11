using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Admin;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.VendorServicePacketStatusOperation
{
    public class GetVendorServicePacketStatusByAdminOperations : Operation<GetVendorServicePacketStatusByAdminInput, GetVendorServicePacketStatusByAdminOutput>
    {
        public override void DoExecute()
        {
            GetVendorServicePacketStatusByAdminOutput output = new GetVendorServicePacketStatusByAdminOutput { VendorServicePacketStatus = new List<VendorServicePacketStatusByAdminDto>() };
            var predicate = PredicateBuilder.True<DAL.Context.VendorServicePacketStatus>();
            var vendorServicePacketStatus = this.Uow.GetRepository<DAL.Context.VendorServicePacketStatus>().GetAll(predicate).ToList();
            output.VendorServicePacketStatus = Mapper.Map<List<VendorServicePacketStatus>, List<VendorServicePacketStatusByAdminDto>>(vendorServicePacketStatus);
            Result.Output = output;
        }
    }


}
