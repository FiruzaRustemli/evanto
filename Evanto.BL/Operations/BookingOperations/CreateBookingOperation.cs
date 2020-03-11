using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Linq;
using AutoMapper;
using Evanto.BL.DTOs.User;
using Evanto.BL.Helpers;
using Evanto.BL.Operations.NotificationOperations;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.BookingOperations
{
    public class CreateBookingOperation : Operation<CreateBookingInput, CreateBookingOutput>
    {
        #region Parameters


        public int StatusId
        {
            get
            {
                return 1;
            }
        }
        #endregion

        #region Constructor
        #endregion

        #region Methods
        #endregion
        public override void DoExecute()
        {
            //TODO: Do ErrorResult implementation here.

            var bookDate = this.Parameters.BookDate.Date;

            if (this.Uow.GetRepository<Booking>().GetAll().Any(x => DbFunctions.TruncateTime(x.BookDate) == bookDate
            && x.UserServiceId == Parameters.UserServiceId
            && x.VendorServiceId == Parameters.VendorServiceId))
            {
                Result.ErrorList.Add(new Error
                {
                    Text = "You have already  booked this service  for this date."
                });

                return;
            }

            CreateBookingOutput output = new CreateBookingOutput();
            Booking booking = Mapper.Map<CreateBookingInput, Booking>(this.Parameters);
            booking.StatusId = StatusId;

            this.Uow.GetRepository<Booking>().Add(booking);
            this.Uow.SaveChanges();

            var bookingUser = Uow.GetRepository<User>().GetById((int)booking.UserId);
            var bookingVendorService = Uow.GetRepository<VendorService>().GetById((int)booking.VendorServiceId);

            var bookingNotificationByUserInput = new CreateBookingNotificationByUserInput()
            {
                ReceiverId = Parameters.VendorId,
                AdditionalData = new BookingNotificationAdditionalDataUserDto()
                {
                    BookingId = booking.Id,
                    ResourceKey = "BookingNotificationText",
                    UserName = bookingUser?.FirstName + " " + bookingUser?.LastName,
                    VendorServiceName = bookingVendorService?.Name
                }.ToJson(),
                SenderId = Parameters.CurrentUserId

            };

            var bookingNotificationByUserOperation = new CreateBookingNotificationByUserOperation();

            bookingNotificationByUserOperation.Execute(bookingNotificationByUserInput);

            if (!bookingNotificationByUserOperation.Result.IsSuccess)
            {
                Result.ErrorList.Add(new Error
                {
                    Text = "Booking request notification could not be sent."
                });

                return;
            }


            output.IsCreated = true;
            Result.Output = output;
        }
    }
}
