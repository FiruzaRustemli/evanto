using AutoMapper;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.BookingOperations
{
    public class CreateBookingByAdminOperation : Operation<CreateBookingByAdminInput, CreateBookingByAdminOutput>
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
            CreateBookingByAdminOutput output = new CreateBookingByAdminOutput();
            Booking booking = Mapper.Map<CreateBookingByAdminInput, Booking>(this.Parameters);
            booking.StatusId = StatusId;
            
            this.Uow.GetRepository<Booking>().Add(booking);
            this.Uow.SaveChanges();

            output.BookingId = booking.Id;
            output.IsCreated = true;
            Result.Output = output;
        }
    }
}
