using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.Vendor;
using Evanto.BL.Helpers;
using Evanto.BL.Operations.NotificationOperations;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.BookingOperations
{
    public class ChangeStatusBookingByVendorOperation : Operation<ChangeStatusBookingByVendorInput, ChangeStatusBookingByVendorOutput>
    {
        #region Parameters
        #endregion

        #region Constructor        
        #endregion

        #region Methods

        public override void DoExecute()
        {
            ChangeStatusBookingByVendorOutput output = new ChangeStatusBookingByVendorOutput();
            Booking booking = this.Uow.GetRepository<Booking>()
                .Get(b => b.Id == this.Parameters.Id && b.VendorId == this.Parameters.CurrentUserId);

            var bookingNotificationByVendorInput = new CreateBookingNotificationByVendorInput()
            {
                ReceiverId = booking.UserId.Value,
                AdditionalData = new BookingNotificationAdditionalDataVendorDto()
                {
                    BookingId = booking.Id,
                    NewStatusId = Parameters.StatusId,
                    OldStatusId = booking.StatusId,
                    ResourceKey = "BookingNotificationText",
                    
                }.ToJson(),
                SenderId = Parameters.CurrentUserId                
            };

            booking.StatusId = this.Parameters.StatusId;

            this.Uow.GetRepository<Booking>().Update(booking);
            this.Uow.SaveChanges();


            var bookingNotificationByVendorOperation = new CreateBookingNotificationByVendorOperation();

            bookingNotificationByVendorOperation.Execute(bookingNotificationByVendorInput);

            if (!bookingNotificationByVendorOperation.Result.IsSuccess)
            {
                Result.ErrorList.Add(new Error
                {
                    Text = "Booking request notification could not be sent."
                });

                return;
            }

            output.Booking = Mapper.Map<Booking, BookingVendorDto>(booking);
            output.IsUpdated = true;
            Result.Output = output;
        }

        #endregion

    }
}
