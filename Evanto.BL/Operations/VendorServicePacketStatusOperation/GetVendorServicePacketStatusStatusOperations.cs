using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.VendorServicePacketStatusOperation
{
    public class GetVendorServicePacketStatusOperation : Operation<GetVendorServicePacketStatusInput, GetVendorServicePacketStatusOutput>
    {
        public override void DoExecute()
        {
            GetVendorServicePacketStatusOutput output = new GetVendorServicePacketStatusOutput { VendorServicePacketStatus = new List<VendorServicePacketStatusDto>() };
            var predicate = PredicateBuilder.True<DAL.Context.VendorServicePacketStatus>();
            var vendorServicePacketStatus = this.Uow.GetRepository<DAL.Context.VendorServicePacketStatus>().GetAll(predicate).ToList();
            output.VendorServicePacketStatus = Mapper.Map<List<VendorServicePacketStatus>, List<VendorServicePacketStatusDto>>(vendorServicePacketStatus);
            Result.Output = output;
        }
    }


}
