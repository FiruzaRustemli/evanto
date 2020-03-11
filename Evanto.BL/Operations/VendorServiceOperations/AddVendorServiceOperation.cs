using System;
using System.Collections.Generic;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.Vendor;
using Evanto.BL.Operations.VendorServicePacketOperation;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.VendorServiceOperations
{
    public class AddVendorServicesOperation : Operation<AddVendorServicesInput, AddVendorServicesOutput>
    {
        public override void DoExecute()
        {
            AddVendorServicePacketOperation addVendorServicePacketOperation =
                new AddVendorServicePacketOperation();
            AddVendorServicePacketInput addVendorServicePacketInput =
                Mapping<AddVendorServicesInput, AddVendorServicePacketInput>.MapToDto(this.Parameters);
            addVendorServicePacketInput.VendorId = this.Parameters.CurrentUserId;
            addVendorServicePacketInput.Payment.VendorId = this.Parameters.CurrentUserId;
            OperationResult<AddVendorServicePacketOutput> addVendorServicePacketOperationResult =
                addVendorServicePacketOperation.Execute(addVendorServicePacketInput);

            Result.Output = new AddVendorServicesOutput();
            if (addVendorServicePacketOperationResult.IsSuccess &&
                addVendorServicePacketOperationResult.Output.IsCreated == true)
            {
                foreach (var item in this.Parameters.VendorServices)
                {
                    item.DiscountCouponId = addVendorServicePacketOperationResult.Output.VendorServicePacket.DiscountCouponId;
                    item.VendorServicePacketId = addVendorServicePacketOperationResult.Output.VendorServicePacket.Id;
                    item.Status = false;
                    item.CreatedDate = DateTime.UtcNow.AddHours(4);
                    item.ActivationDate = item.ActivationDate == DateTime.MinValue ? null : item.ActivationDate;
                    item.EndDate = item.EndDate == DateTime.MinValue ? null : item.EndDate;
                }
                this.Uow.GetRepository<VendorService>().AddRange(this.Parameters.VendorServices);
                this.Uow.SaveChanges();
                Result.Output.IsCreated = true;
                Result.Output.VendorServicePacket = addVendorServicePacketOperationResult.Output.VendorServicePacket;
            }
            else
            {
                Result.Output.IsCreated = false;
            }
        }
    }
}
