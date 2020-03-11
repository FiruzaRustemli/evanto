using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.BL.DTOs.Public;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.PublicOperations
{
    public class GetVendorServiceImageOperation : Operation<GetVendorServiceImageInput, GetVendorServiceImageOutput>
    {
        public override void DoExecute()
        {
            this.Parameters = Parameters ?? new GetVendorServiceImageInput();

            GetVendorServiceImageOutput output = new GetVendorServiceImageOutput();

            var files = this.Uow.GetRepository<File>().GetAll(f => f.ContentTypeId == 1
                                                                   && f.TypeId == this.Parameters.TypeId
                                                                   && f.RelationalId == this.Parameters.RelationalId);
            if (this.Parameters.ParentId != null)
            {
                files = files.Where(f => f.Id == this.Parameters.ParentId);
            }


            // We need to check if requested images are in thumbnail type. 
            // If not we must return only first image because returning all images can cause network overload.
            if (this.Parameters.TypeId == 1)
            {
                output.VendorServiceImages =
                    files.OrderBy(f => f.Id).Take(1).ToList().Select(f => new VendorServiceImageDto()
                    {
                        ParentId = f.ParentId,
                        Image =
                            System.IO.File.Exists(ConfigHelper.GetAppSetting("FileSaveServer") + f.Path)
                                ? Convert.ToBase64String(
                                    System.IO.File.ReadAllBytes(ConfigHelper.GetAppSetting("FileSaveServer") + f.Path))
                                : null
                    }).ToList();
            }
            else
            {
                output.VendorServiceImages = files.ToList().Select(f => new VendorServiceImageDto()
                {
                    ParentId = f.ParentId,
                    Image = System.IO.File.Exists(ConfigHelper.GetAppSetting("FileSaveServer") + f.Path) ? Convert.ToBase64String(System.IO.File.ReadAllBytes(ConfigHelper.GetAppSetting("FileSaveServer") + f.Path)) : null
                }).ToList();
            }


            Result.Output = output;
        }
    }
}
