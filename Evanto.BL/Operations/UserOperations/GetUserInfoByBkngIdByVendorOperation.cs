using Evanto.BL.DTOs.Vendor;
using Evanto.DAL.Context;
using Evanto.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.UserOperations
{
    public class GetUserInfoByBkngIdByVendorOperation : Operation<GetUserInfoByBkngIdByVendorInput, GetUserInfoByBkngIdByVendorOutput>
    {
        public override void DoExecute()
        {
            var booking = Uow.GetRepository<Booking>()
                .GetAll(s => s.Id == this.Parameters.BookingId && s.VendorId == this.Parameters.CurrentUserId)
                .Select(s => new
                {
                    Booking = s,
                    UserId = s.UserId,
                    UserServiceId = s.UserServiceId,
                    UserServiceName = s.UserService == null ? "": s.UserService.Service.Name,
                    UserEventId = s.UserService == null ? 0 : s.UserService.UserEvent.EventId                    
                }).First();

            var eventName = Uow.GetRepository<EventType>().GetById(booking.UserEventId)?.Name;

            UserVendorDto userDto = booking.UserId == null ? new UserVendorDto() : Mapper.Map<User, UserVendorDto>(Uow.GetRepository<User>().GetById((int)booking.UserId));
            var user = Uow.GetRepository<File>()
                .Get(p => p.ContentTypeId == 1
                && p.RelationalId == userDto.Id
                && p.Status == true);
                userDto.Url = (user?.Path != null && System.IO.File.Exists(ConfigHelper.GetAppSetting("FileSaveServer") + user?.Path)) ? Convert.ToBase64String(System.IO.File.ReadAllBytes(ConfigHelper.GetAppSetting("FileSaveServer") + user?.Path)) : null;


            GetUserInfoByBkngIdByVendorOutput output = new GetUserInfoByBkngIdByVendorOutput();
            output.User = userDto;
            output.Booking = Mapper.Map<Booking, BookingVendorDto>(booking.Booking);
            output.User.Password = null;
            output.User.Salt = null;
            output.EventId = booking.UserEventId;
            output.EventName = eventName;
            output.ServiceId = booking.UserServiceId != null ? (int)booking.UserServiceId : 0;
            output.ServiceName = booking.UserServiceName;
            Result.Output = output;
        }
    }
}
