using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Admin;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.VendorServicePacketOperation
{
    public class GetVendorServicePacketByAdminOperation : Operation<GetVendorServicePacketByAdminInput, GetVendorServicePacketByAdminOutput>
    {
        public override void DoExecute()
        {
            GetVendorServicePacketByAdminOutput output = new GetVendorServicePacketByAdminOutput();
            var predicate = PredicateBuilder.True<VendorServicePacket>();

            if(Parameters.Id != null) predicate = predicate.And(v => v.Id == Parameters.Id);

            if(Parameters.DiscountCouponId != null) predicate = predicate.And(v => v.DiscountCouponId == Parameters.DiscountCouponId);

            if(Parameters.PaymentId != null) predicate = predicate.And(v => v.PaymentId == Parameters.PaymentId);


            if(Parameters.StatusId != null) predicate = predicate.And(v => v.StatusId == Parameters.StatusId);

            var vendorServicePackets = Uow.GetRepository<VendorServicePacket>().GetAll(predicate).ToList();
            output.VendorServicePackets = Mapper.Map<List<VendorServicePacket>, List<VendorServicePacketByAdminDto>>(vendorServicePackets);
            Result.Output = output;
        }
    }
}
