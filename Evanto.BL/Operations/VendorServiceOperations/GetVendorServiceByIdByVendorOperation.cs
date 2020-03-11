using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.DAL.Context;
using Evanto.BL.DTOs.Vendor;
using Evanto.Utils;

namespace Evanto.BL.Operations.VendorServiceOperations
{
    public class GetVendorServiceByIdByVendorOperation : Operation<GetVendorServiceByIdByVendorInput, GetVendorServiceByIdByVendorOutput>
    {
        public override void DoExecute()
        {
            var VendorService = Uow.GetRepository<VendorService>().Get(vs =>
            vs.Id == this.Parameters.Id &&
            vs.VendorServicePacket.VendorId == this.Parameters.CurrentUserId);

            var images = Uow.GetRepository<DAL.Context.File>().GetAll(image =>
                image.RelationalId == Parameters.Id
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
            var vendorServiceDto = Mapper.Map<VendorService, VendorServiceVendorDto>(VendorService);
            vendorServiceDto.Images = imageDtoList;
            Result.Output = new GetVendorServiceByIdByVendorOutput();
            Result.Output.VendorService = vendorServiceDto;
        }
    }
}
