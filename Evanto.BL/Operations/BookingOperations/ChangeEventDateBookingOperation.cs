using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.BookingOperations
{
    public class ChangeEventDateBookingOperation : Operation<ChangeEventDateBookingInput, ChangeEventDateBookingOutput>
    {
        #region Parameters
        #endregion
        #region Constructor
        #endregion
        #region Methods
        #endregion
        

        public override void DoExecute()
        {
            ChangeEventDateBookingOutput output = new ChangeEventDateBookingOutput();
            Booking booking = this.Uow.GetRepository<Booking>().GetById(this.Parameters.Id);
            booking.Deadline = this.Parameters.Deadline;

            this.Uow.GetRepository<Booking>().Update(booking);
            this.Uow.SaveChanges();
            this.Uow.Dispose();
            output.Booking =Mapper.Map<Booking, BookingDto>(booking);
            output.IsUpdated = true;
            Result.Output = output;
        }
    }
}
