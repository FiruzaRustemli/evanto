using System.Linq;
using Evanto.BL.Operations.DiscountCouponOperations;
using Evanto.BL.Operations.PaymentOperations;
using Evanto.DAL.Context;
using Evanto.BL.DTOs.Vendor;

namespace Evanto.BL.Operations.VendorServicePacketOperation
{
    public class AddVendorServicePacketOperation : Operation<AddVendorServicePacketInput, AddVendorServicePacketOutput>
    {
        public override void DoExecute()
        {
            var discountCoupon = this.Uow.GetRepository<DiscountCoupon>().
                   GetAll(d => d.CouponNumber == this.Parameters.CouponNumber
                   && d.StatusId == 1). //TODO.
                   FirstOrDefault();
            if (discountCoupon != null)
            {
                if (discountCoupon.DiscountTypeId == (int)Utils.Enums.DiscountType.Amount)
                {
                    this.Parameters.Payment.Amount = this.Parameters.Payment.Amount - discountCoupon.Quantity;
                }
                else
                {
                    this.Parameters.Payment.Amount = this.Parameters.Payment.Amount - (this.Parameters.Payment.Amount * discountCoupon.Quantity / 100);
                }
                //UpdateDiscountCouponInput updateDiscountCouponInput =
                //    Mapping<DiscountCoupon, UpdateDiscountCouponInput>
                //    .MapToDto(discountCoupon);
                //updateDiscountCouponInput.Quantity -= 1;
                //UpdateDiscountCouponOperation updateDiscountCouponOperation =
                //    new UpdateDiscountCouponOperation();
                //OperationResult<UpdateDiscountCouponOutput> updateDiscountCouponOperationResult =
                //    updateDiscountCouponOperation.Execute(updateDiscountCouponInput);
                //if (!updateDiscountCouponOperationResult.IsSuccess)
                //{
                //    //Result.ErrorList = updateDiscountCouponOperationResult.ErrorList;
                //    return;
                //}
            }
            CreatePaymentOperation addPaymentOperation =
            new CreatePaymentOperation();
            CreatePaymentInput addPayment = Mapper.Map<Payment, CreatePaymentInput>(this.Parameters.Payment);
            OperationResult<CreatePaymentOutput> addPaymentOperationResult =
                addPaymentOperation.Execute(addPayment);

            Result.Output = new AddVendorServicePacketOutput();
            if (addPaymentOperationResult.IsSuccess && addPaymentOperationResult.Output.IsCreated == true)
            {
                VendorServicePacket vendorServicePacket = new VendorServicePacket();
                vendorServicePacket.VendorId = this.Parameters.VendorId;
                vendorServicePacket.StatusId = this.Parameters.VendorServicePacketStatusId; //TODO
                vendorServicePacket.PaymentId = addPaymentOperationResult.Output.PaymentId;
                if (discountCoupon != null)
                {
                    vendorServicePacket.DiscountCouponId = discountCoupon.Id;
                }
                this.Uow.GetRepository<VendorServicePacket>().Add(vendorServicePacket);
                this.Uow.SaveChanges();
                
                Result.Output.VendorServicePacket = Mapper.Map<VendorServicePacket, VendorServicePacketVendorDto>(Uow.GetRepository<VendorServicePacket>().GetById(vendorServicePacket.Id));
                Result.Output.IsCreated = true;
            }
            else
            {
                Result.Output.IsCreated = false;
            }
        }
    }
}
