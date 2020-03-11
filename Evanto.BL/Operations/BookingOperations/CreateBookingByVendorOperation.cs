using AutoMapper;
using Evanto.BL.DTOs.Vendor;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.BookingOperations
{
    public class CreateBookingByVendorOperation : Operation<CreateBookingByVendorInput, CreateBookingByVendorOutput>
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
            CreateBookingByVendorOutput output = new CreateBookingByVendorOutput();
            Booking booking = Mapper.Map<CreateBookingByVendorInput, Booking>(this.Parameters);
            booking.StatusId = StatusId;
            booking.VendorId = this.Parameters.CurrentUserId;
            booking.VendorServiceId = this.Parameters.VendorServiceId;
            this.Uow.GetRepository<Booking>().Add(booking);
            this.Uow.SaveChanges();

            var newBooking = Uow.GetRepository<Booking>().Get(a => a.UserId == null && a.Id == booking.Id);
            var newBookingDto = new BookingVendorDto
            {
                Id = newBooking.Id,
                BookDate = newBooking.BookDate,
                CreatedDate = newBooking.CreatedDate,
                ServiceName = newBooking.UserService?.Service.Name,
                Deadline = newBooking.Deadline,
                Description = newBooking.Description,
                StatusId = 4,//client side validation
                PhoneNumber = newBooking.User?.Phone,
                UserFullName = newBooking.User?.FirstName + " " + newBooking.User?.LastName,
                UserId = newBooking.UserId,
                UserServiceId = newBooking.UserServiceId,
                VendorId = newBooking.VendorId
            };
            output.Booking = newBookingDto;
            output.BookingId = booking.Id;
            output.IsCreated = true;
            Result.Output = output;
        }
    }
}
