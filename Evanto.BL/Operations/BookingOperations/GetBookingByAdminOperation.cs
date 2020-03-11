using Evanto.DAL.Context;
using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Admin;
using Evanto.BL.DTOs.Vendor;

namespace Evanto.BL.Operations.BookingOperations
{
    public class GetBookingByAdminOperation : Operation<GetBookingByAdminInput, GetBookingByAdminOutput>
    {
        public override void DoExecute()
        {
            GetBookingByAdminOutput output = new GetBookingByAdminOutput();
            List<Booking> bookings;
            if (Parameters.StatusId == 0)
            {
                bookings = Uow.GetRepository<Booking>().GetAll(a => a.VendorId == Parameters.VendorId).ToList();
            }else if(Parameters.StatusId == 4)
            {
                bookings = Uow.GetRepository<Booking>().GetAll(a => a.UserId == null).ToList();
            }
            else
            {
                bookings = Uow.GetRepository<Booking>().GetAll(a => a.StatusId == Parameters.StatusId && a.VendorId == Parameters.VendorId).ToList();
            }            
            output.Bookings = Mapper.Map<List<Booking>, List<BookingAdminDto>>(bookings);
            
            Result.Output = output;
        }
    }
}
