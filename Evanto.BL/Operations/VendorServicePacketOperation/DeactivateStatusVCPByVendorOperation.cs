using Evanto.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.VendorServicePacketOperation
{
    public class DeactivateStatusVCPByVendorOperation : Operation<DeactivateStatusVSPByVendorInput, DeactivateStatusVSPByVendorOutput>
    {
        public override void DoExecute()
        {
            var vendorServicePacket = Uow.GetRepository<VendorServicePacket>()
                .Get(vsp => vsp.Id == this.Parameters.Id && vsp.VendorId == this.Parameters.CurrentUserId);
            vendorServicePacket.StatusId = (int)Utils.Enums.VendorServicePacketStatusValue.Deactive;
            Uow.GetRepository<VendorServicePacket>().Update(vendorServicePacket);
            Uow.SaveChanges();
            Result.Output.IsDeactivated = true;
        }
    }
}
