using Evanto.BL.DTOs.Vendor;
using Evanto.DAL.Context;
using Evanto.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.VendorServiceOperations
{
    public class UpdateVendorServiceOperation : Operation<UpdateVendorServiceInput, UpdateVendorServiceOutput>
    {
        public override void DoExecute()
        {
            var vendorService = Uow.GetRepository<VendorService>().GetById(this.Parameters.VendorServiceId);
            vendorService.Name = Parameters.Name;
            vendorService.PriceMin = this.Parameters.PriceMin;
            vendorService.PriceMax = this.Parameters.PriceMax;
            vendorService.DailyQuantity = 0;
            vendorService.Description = !String.IsNullOrEmpty(this.Parameters.Description) ? this.Parameters.Description : vendorService.Description;
            vendorService.AddressText = Parameters.AddressText;
            vendorService.ContactInfo = Parameters.ContactInfo;
            vendorService.CoordinateX = Parameters.CoordinateX;
            vendorService.CoordinateY = Parameters.CoordinateY;

            var images = Uow.GetRepository<DAL.Context.File>().GetAll(image =>
                image.RelationalId == Parameters.VendorServiceId
                && image.TypeId == 3
                && image.Status == true).OrderByDescending(s => s.Id).ToList(); //TODO: and type vendorService
            var imageDtoList = new List<FileVendorDto>();
            if (images != null)
            {
                images.ForEach(image =>
                {
                    string filePathToSave = $"{ConfigHelper.GetAppSetting("FileSavePath")}{image.Name}.{image.Extension}";
                    var imageDto = Mapper.Map<DAL.Context.File, FileVendorDto>(image);
                    imageDto.Container = filePathToSave != null && System.IO.File.Exists(ConfigHelper.GetAppSetting("FileSaveServer") + filePathToSave) ? Convert.ToBase64String(System.IO.File.ReadAllBytes(ConfigHelper.GetAppSetting("FileSaveServer") + filePathToSave)) : null;
                    imageDtoList.Add(imageDto);
                });
            }


            Uow.GetRepository<VendorService>().Update(vendorService);
            Uow.SaveChanges();

            var output = new UpdateVendorServiceOutput();
            output.VendorService = Mapper.Map<VendorService, VendorServiceVendorDto>(vendorService);
            output.VendorService.Images = imageDtoList;
            Result.Output = output;
        }
    }
}
