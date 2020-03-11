using Evanto.BL.DTOs.Vendor;
using Evanto.DAL.Context;
using Evanto.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.BookingOperations
{
    public class GetBookingByVendorOperation : Operation<GetBookingByVendorInput, GetBookingByVendorOutput>
    {
        public override void DoExecute()
         {
            GetBookingByVendorOutput output = new GetBookingByVendorOutput();
            Expression<Func<Booking, bool>> predicate;
            var datetime = this.Parameters.Date;
            if (this.Parameters.StatusId == 0)
            {
                predicate = a => a.VendorId == this.Parameters.CurrentUserId 
                && a.StatusId != 3 
                && (this.Parameters.Date == null
                        ? true
                        : a.BookDate.Month == datetime.Value.Month);
            }
            else if (this.Parameters.StatusId == 4)
            {
                predicate = a => a.UserId == null 
                && a.VendorId == this.Parameters.CurrentUserId
                && (this.Parameters.Date == null
                        ? true
                        : a.BookDate.Month == datetime.Value.Month);
            }
            else if (this.Parameters.StatusId == 7)
            {
                predicate = a => a.UserId != null
                && a.StatusId == 1
                && a.VendorId == this.Parameters.CurrentUserId;
            }
            else
            {
                predicate = a => a.UserId != null 
                && a.StatusId == this.Parameters.StatusId 
                && a.VendorId == this.Parameters.CurrentUserId
                && (this.Parameters.Date == null 
                        ? true 
                        : a.BookDate.Month == datetime.Value.Month);
            }

            List<BookingVendorDto> bookings = Uow.GetRepository<Booking>().GetAll(predicate).Select(s => new BookingVendorDto
            {
                Id = s.Id,
                BookDate = s.BookDate,
                CreatedDate = s.CreatedDate,
                ServiceName = s.UserService.Service.Name,
                Deadline = s.Deadline,
                Description = s.Description,
                StatusId = s.StatusId,
                PhoneNumber = s.User.Phone,
                UserFullName = s.User.FirstName + " " + s.User.LastName,
                UserId = s.UserId,
                UserServiceId = s.UserServiceId,
                VendorId = s.VendorId
            }).ToList();
            List<int?> userIds = bookings.Select(s => s.UserId).ToList();
            var files = Uow.GetRepository<File>().GetAll(p => p.ContentTypeId == 1
                && userIds.Contains(p.RelationalId)
                && p.Status == true).Select(f => new FileVendorDto
                {
                    Path = f.Path,
                    RelationalId = f.RelationalId
                }).ToList();

            foreach (var item in bookings)
            {
                item.UserImagePath = item.UserId != null ? files?.FirstOrDefault(f => f.RelationalId == item.UserId)?.Path : "";
            }

            bookings.ForEach(item =>
            {
                if(item.UserId != null)
                {
                    var filePathToSave = files?.FirstOrDefault(f => f.RelationalId == item.UserId)?.Path;
                    item.UserImagePath = filePathToSave != null && System.IO.File.Exists(ConfigHelper.GetAppSetting("FileSaveServer") + filePathToSave) ? Convert.ToBase64String(System.IO.File.ReadAllBytes(ConfigHelper.GetAppSetting("FileSaveServer") + filePathToSave)) : null;
                }
            });

            output.Bookings = bookings;
            output.Bookings.ForEach(s => {
                if (s.UserId == null)
                {
                    s.StatusId = 4;
                }
            });
            Result.Output = output;
        }
    }
}
