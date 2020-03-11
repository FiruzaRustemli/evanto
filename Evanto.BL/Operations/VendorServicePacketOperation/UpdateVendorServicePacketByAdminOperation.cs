using System;
using Evanto.BL.DTOs.Admin;
using Evanto.DAL.Context;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.VendorServicePacketOperation
{
    public class UpdateVendorServicePacketByAdminOperation : Operation<UpdateVendorServicePacketByAdminInput, UpdateVendorServicePacketByAdminOutput>
    {
        public override void DoExecute()
        {

            var output = new UpdateVendorServicePacketByAdminOutput();
            var data = Uow.GetRepository<VendorServicePacket>().GetById(Parameters.Id);
            if (Parameters.StatusId == (int)VendorServicePacketStatusValue.Active&&
                    (data.StatusId == (int)VendorServicePacketStatusValue.Deactive||
                    data.StatusId == (int)VendorServicePacketStatusValue.Waiting ))
            {
                data.ActivationDate = DateTime.Now;
                foreach (var item in data.VendorService)
                {
                    item.ActivationDate = data.ActivationDate;
                    item.Status = true;
                    item.EndDate = data.ActivationDate.Value.AddDays(item.ServicePeriodPrice.Period.Duration);
                }
            }
            data.StatusId = Parameters.StatusId;
            data.Description = Parameters.Description;
            
            Uow.GetRepository<VendorServicePacket>().Update(data);
            Uow.SaveChanges();
            output.VendorServicePacketByAdminDto = Mapper.Map<VendorServicePacket, VendorServicePacketByAdminDto>(data);
            Result.Output = output;
        }
    }
}
