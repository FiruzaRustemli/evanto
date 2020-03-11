using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.BookingOperations
{
    public class GetBookingByUserOperation : Operation<GetBookingByUserInput, GetBookingByUserOutput>
    {

        public override void DoExecute()
        {
            GetBookingByUserOutput output = new GetBookingByUserOutput();
            var predicate = PredicateBuilder.True<Booking>();

            predicate = predicate.And(b => b.UserId == this.Parameters.CurrentUserId);

            if (this.Parameters.Id != null)
            {
                predicate = predicate.And(b => b.Id == this.Parameters.Id);
            }

            if (this.Parameters.VendorId != null)
            {
                predicate = predicate.And(b => b.VendorId == this.Parameters.VendorId);
            }

            if (this.Parameters.VendorServiceId != null)
            {
                predicate = predicate.And(b => b.VendorServiceId == this.Parameters.VendorServiceId);
            }

            if (this.Parameters.ServiceId != null)
            {
                predicate = predicate.And(b => b.UserService.ServiceId == this.Parameters.ServiceId);
            }

            if (this.Parameters.StatusId != null)
            {
                predicate = predicate.And(b => b.StatusId == this.Parameters.StatusId);
            }

            if (this.Parameters.EventId != null)
            {
                predicate = predicate.And(b => b.UserService.UserEventId == this.Parameters.EventId);
            }


            if (this.Parameters.SearchText != null)
            {
                predicate = predicate.And(b => b.Vendor.User.FirstName.Contains(this.Parameters.SearchText) ||
                                               b.Vendor.User.LastName.Contains(this.Parameters.SearchText) ||
                                               b.UserService.Service.Name.Contains(this.Parameters.SearchText) ||
                                               b.UserService.UserEvent.Name.Contains(this.Parameters.SearchText));
            }

            var bookings = this.Uow.GetRepository<Booking>().GetAll(predicate, 
                                                                         "UserService",
                                                                         "Vendor")
                .ToList();

            var bookingDtos = Mapper.Map<List<Booking>, List<BookingUserDto>>(bookings);

            foreach (var bookingUserDto in bookingDtos)
            {
                var vendorServicePhoto = Uow.GetRepository<File>().GetAll(p => p.ContentTypeId == 1
                                                                               && p.RelationalId == bookingUserDto.VendorService.Id
                                                                               && p.Status == true).FirstOrDefault();

                if (vendorServicePhoto != null)
                {
                    string filePath = $"{ConfigHelper.GetAppSetting("FileSavePath")}{vendorServicePhoto.Name}.{vendorServicePhoto.Extension}";
                    bookingUserDto.VendorService.Photo = System.IO.File.Exists(ConfigHelper.GetAppSetting("FileSaveServer") + filePath) ? Convert.ToBase64String(System.IO.File.ReadAllBytes(ConfigHelper.GetAppSetting("FileSaveServer") + filePath)) : null;
                }
            }

            output.Bookings = Mapper.Map<List<Booking>, List<BookingUserDto>>(bookings);
            Result.Output = output;
        }
    }
}
