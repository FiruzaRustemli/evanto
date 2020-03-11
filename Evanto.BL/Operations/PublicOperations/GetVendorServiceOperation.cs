using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.BL.DTOs.Public;
using Evanto.DAL.Context;
using Evanto.BL.DTOs.User;
using Evanto.Utils;

namespace Evanto.BL.Operations.PublicOperations
{
    public class GetVendorServiceOperation : Operation<GetVendorServiceInput, GetVendorServiceOutput>
    {
        public override void DoExecute()
        {
            this.Parameters = Parameters ?? new GetVendorServiceInput();

            var vendorService = this.Uow.GetRepository<VendorService>().GetById(this.Parameters.Id);
            var output = new GetVendorServiceOutput();
            Vendor vendor = null;
            List<VendorService> otherVendorServices = new List<VendorService>();
            List<RatingUserDto> userRatings = new List<RatingUserDto>();

            if (vendorService != null)
            {
                userRatings = vendorService.Rating1.Select(r => new RatingUserDto
                {
                    Rating = r.Value.ToString("0.00").Replace(',', '.'),
                    CreatedDate = r.CreatedDate,
                    Username = r.User.Username,
                    FullName = r.User.FirstName + ' ' + r.User.LastName,
                    Description = r.Description
                }).ToList();

                vendor = vendorService.VendorServicePacket.Vendor;
                //otherVendorServices = this.Uow.GetRepository<VendorService>().GetAll(s => s.VendorServicePacket.VendorId == vendor.UserId).ToList();
            }

            var vendorDto = Mapper.Map<Vendor, VendorPublicDto>(vendor);


            var vendorPhoto = Uow.GetRepository<File>().Get(p => p.ContentTypeId == 1
                                                                 && p.RelationalId == vendor.UserId
                                                                 && p.Status == true);

            if (vendorPhoto != null)
            {
                string filePath = $"{ConfigHelper.GetAppSetting("FileSavePath")}{vendorPhoto.Name}.{vendorPhoto.Extension}";
                vendorDto.Photo = System.IO.File.Exists(ConfigHelper.GetAppSetting("FileSaveServer") + filePath) ? Convert.ToBase64String(System.IO.File.ReadAllBytes(ConfigHelper.GetAppSetting("FileSaveServer") + filePath)) : null;
            }

            output.Vendor = vendorDto;
            output.UserRatings = userRatings;
            output.VendorService = Mapper.Map<VendorService, VendorServicePublicDto>(vendorService);
            output.VendorService.ServiceName = vendorService.ServicePeriodPrice.Service.Name;
            output.VendorService.ServiceId = vendorService.ServicePeriodPrice.ServiceId;
            //output.OtherVendorServices = Mapper.Map<List<VendorService>, List<VendorServicePublicDto>>(otherVendorServices);


            Result.Output = output;
        }
    }
}
