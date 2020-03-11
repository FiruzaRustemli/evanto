using Evanto.BL.DTOs.Vendor;
using Evanto.DAL.Context;
using Evanto.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.VendorOperations
{
    public class GetVendorByIdByVendorOperation : Operation<GetVendorByIdByVendorInput, GetVendorByIdByVendorOutput>
    {
        public override void DoExecute()
        {
            GetVendorByIdByVendorOutput output = new GetVendorByIdByVendorOutput();
            Vendor vendor = Uow.GetRepository<Vendor>().Get(v => v.UserId == this.Parameters.CurrentUserId);
            VendorVendorDto vendorDto = Mapper.Map<Vendor, VendorVendorDto>(vendor);
            File profilePhoto = Uow.GetRepository<File>()
                .Get(p => p.ContentTypeId == 1 
                && p.RelationalId == this.Parameters.CurrentUserId 
                && p.Status == true);               
            var userSetting = vendor.User.UserSetting.FirstOrDefault(u => u.UserId == vendor.UserId);
            vendorDto.UserSettings.LanguageId = userSetting.LangId;
            vendorDto.UserSettings.Theme = userSetting.Theme;
            vendorDto.UserSettings.Id = userSetting.Id;

           

            vendorDto.File = Mapper.Map<File, FileVendorDto>(profilePhoto);
            if(profilePhoto != null)
            {
                string filePathToSave = $"{ConfigHelper.GetAppSetting("FileSavePath")}{profilePhoto.Name}.{profilePhoto.Extension}";
                vendorDto.File.Container = filePathToSave != null && System.IO.File.Exists(ConfigHelper.GetAppSetting("FileSaveServer") + filePathToSave) ? Convert.ToBase64String(System.IO.File.ReadAllBytes(ConfigHelper.GetAppSetting("FileSaveServer") + filePathToSave)) : null;
            }
            output.Vendor = vendorDto;
            Result.Output = output;
        }
    }
}
