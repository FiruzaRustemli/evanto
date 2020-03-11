using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.BookingOperations
{
    public class ChangeStatusBookingOperation : Operation<ChangeStatusBookingInput, ChangeStatusBookingOutput>
    {
        #region Parameters
        #endregion

        #region Constructor        
        #endregion

        #region Methods
        #endregion
        

        public override void DoExecute()
        {
            ChangeStatusBookingOutput output = new ChangeStatusBookingOutput();
            Booking booking = this.Uow.GetRepository<Booking>().GetById(this.Parameters.Id);
            booking.StatusId = this.Parameters.StatusId;

            this.Uow.GetRepository<Booking>().Update(booking);
            this.Uow.SaveChanges();

            output.Booking = Mapper.Map<Booking, BookingDto>(booking);
            output.IsUpdated = true;
            Result.Output = output;

        }
    }
}
