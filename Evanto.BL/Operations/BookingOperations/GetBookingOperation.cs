using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.BookingOperations
{
    public class GetBookingOperation : Operation<GetBookingInput, GetBookingOutput>
    {

        public override void DoExecute()
        { 
            GetBookingOutput output = new GetBookingOutput();
            var bookings = this.Uow.EvantoContext.SearchBooking(this.Parameters.Id,
                    this.Parameters.UserId,
                    this.Parameters.VendorId,
                    this.Parameters.UserServiceId,
                    this.Parameters.StatusId,
                    this.Parameters.BookDate,
                    this.Parameters.CreatedTime)
                .ToList();
            output.Bookings = Mapper.Map<List<Booking>, List<BookingDto>>(bookings);
            Result.Output = output;
        }
    }
}
