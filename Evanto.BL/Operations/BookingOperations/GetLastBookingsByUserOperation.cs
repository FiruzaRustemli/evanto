using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.BookingOperations
{
    public class GetLastBookingsByUserOperation : Operation<GetLastBookingsByUserInput, GetLastBookingsByUserOutput>
    {

        public override void DoExecute()
        {
            GetLastBookingsByUserOutput output = new GetLastBookingsByUserOutput();
            var predicate = PredicateBuilder.True<Booking>();

            predicate = predicate.And(b => b.UserId == this.Parameters.CurrentUserId);

            
            var bookings = this.Uow.GetRepository<Booking>().GetAll(predicate, "Vendor").OrderByDescending(b => b.Id).Take(5).ToList();

            output.Bookings = Mapper.Map<List<Booking>, List<BookingUserDto>>(bookings);
            Result.Output = output;
        }
    }
}
