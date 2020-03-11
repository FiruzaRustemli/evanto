using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;
using Evanto.BL.Operations.UserServiceOperations;
using Evanto.DAL.Context;
using Evanto.Utils;
using System;

namespace Evanto.BL.Operations.VendorServiceOperations
{
    public class GetTopVendorServicesByUserOperation : Operation<GetTopVendorServicesByUserInput, GetTopVendorServicesByUserOutput>
    {
        public override void DoExecute()
        {
            this.Parameters = Parameters ?? new GetTopVendorServicesByUserInput();

            GetTopVendorServicesByUserOutput output = new GetTopVendorServicesByUserOutput();
            var predicate = PredicateBuilder.True<VendorService>();

            if (this.Parameters.Id != null)
            {
                predicate = predicate.And(v => v.Id == this.Parameters.Id);
            }
            if (this.Parameters.ServicePeriodPriceId != null)
            {
                predicate = predicate.And(v => v.ServicePeriodPriceId == this.Parameters.ServicePeriodPriceId);
            }
            if (this.Parameters.VendorServicePacketId != null)
            {
                predicate = predicate.And(v => v.VendorServicePacketId == this.Parameters.VendorServicePacketId);
            }
            if (this.Parameters.VendorId != null)
            {
                predicate = predicate.And(v => v.VendorServicePacket.VendorId == this.Parameters.VendorId);
            }
            if (this.Parameters.ServiceId != null)
            {
                predicate = predicate.And(v => v.ServicePeriodPrice.ServiceId == this.Parameters.ServiceId);
            }
            if (this.Parameters.ServiceIds.Count > 0)
            {
                predicate = predicate.And(v => this.Parameters.ServiceIds.Contains(v.ServicePeriodPrice.ServiceId));
            }

            if (this.Parameters.EventTypeId != 0)
            {
                predicate = predicate?.And(s => !s.VendorServiceExceptionalEvent.Any(e => e.EventId == this.Parameters.EventTypeId));
            }

            Random random = new Random();

            var vendorServices = this.Uow.GetRepository<VendorService>().GetAll(predicate)
                .Where(s => s.Status).OrderByDescending(o => o.Rating).Take(15)
                .ToList().OrderBy(o => random.Next()).Take(5).ToList();

            var vendoServiceDtos = Mapper.Map<List<VendorService>, List<VendorServiceUserDto>>(vendorServices);

            foreach (var vendorServiceDto in vendoServiceDtos)
            {
                var vendorServicePhoto = Uow.GetRepository<File>().GetAll(p => p.ContentTypeId == 1
                                                                               && p.RelationalId == vendorServiceDto.Id
                                                                               && p.Status == true).FirstOrDefault();

                if (vendorServicePhoto != null)
                {
                    string filePath = $"{ConfigHelper.GetAppSetting("FileSavePath")}{vendorServicePhoto.Name}.{vendorServicePhoto.Extension}";
                    vendorServiceDto.Photo = System.IO.File.Exists(ConfigHelper.GetAppSetting("FileSaveServer") + filePath) ? Convert.ToBase64String(System.IO.File.ReadAllBytes(ConfigHelper.GetAppSetting("FileSaveServer") + filePath)) : null;
                }
            }

            output.VendorServices = vendoServiceDtos;
            Result.Output = output;
        }
    }
}
