using System;
using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;
using Evanto.BL.Operations.UserServiceOperations;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.VendorServiceOperations
{
    public class GetVendorServiceByUserOperation : Operation<GetVendorServiceByUserInput, GetVendorServiceByUserOutput>
    {

        #region Properties

        public int DefaultPageSize => 10;

        #endregion

        #region Constructors

        #endregion

        #region Methods

        public override void DoExecute()
        {
            this.Parameters = Parameters ?? new GetVendorServiceByUserInput();

            GetVendorServiceByUserOutput output = new GetVendorServiceByUserOutput();
            var predicate = PredicateBuilder.True<VendorService>();

            IQueryable<VendorService> query;

            if (this.Parameters.ServiceId != null)
            {
                query = this.Uow.GetRepository<VendorService>()
                    .GetAll(predicate, "VendorServicePacket", "ServicePeriodPrice")
                    .Where(s => s.Status && s.ServicePeriodPrice.ServiceId == this.Parameters.ServiceId);
            }
            else if (this.Parameters.VendorId != null)
            {
                query = this.Uow.GetRepository<VendorService>()
                    .GetAll(predicate, "VendorServicePacket", "ServicePeriodPrice")
                    .Where(s => s.Status && s.VendorServicePacket.VendorId == this.Parameters.VendorId);
            }
            else
            {
                query = null;
            }
            if (this.Parameters.EventTypeId != 0)
            {
                query = query?.Where(s => !s.VendorServiceExceptionalEvent.Any(e => e.EventId == this.Parameters.EventTypeId));
            }

            if (this.Parameters.Filter.PageNumber > 0 && this.Parameters.Filter.PageSize > 0 && this.Parameters.Filter.PageSize < 50 )
            {
                query = query?.OrderBy(a => a.Id).Skip((this.Parameters.Filter.PageNumber - 1) * this.Parameters.Filter.PageSize).Take(this.Parameters.Filter.PageSize);

            }
            else
            {
                query = query?.Take(DefaultPageSize);
            }

            if (!string.IsNullOrEmpty(this.Parameters.Filter.SearchText))
            {
                query = query?.Where(f => f.Name.Contains(this.Parameters.Filter.SearchText));
            }

            var filteredVendorServices = Mapper.Map<List<VendorService>, List<VendorServiceUserDto>>(query?.ToList());

            foreach (var vendorServicePublicDto in filteredVendorServices)
            {
                var vendorServiceDto = Uow.GetRepository<File>().GetAll(p => p.ContentTypeId == 1
                                                                               && p.RelationalId == vendorServicePublicDto.Id
                                                                               && p.Status == true).FirstOrDefault();

                if (vendorServiceDto != null)
                {
                    string filePath = $"{ConfigHelper.GetAppSetting("FileSavePath")}{vendorServiceDto.Name}.{vendorServiceDto.Extension}";
                    vendorServicePublicDto.Photo = System.IO.File.Exists(ConfigHelper.GetAppSetting("FileSaveServer") + filePath) ? Convert.ToBase64String(System.IO.File.ReadAllBytes(ConfigHelper.GetAppSetting("FileSaveServer") + filePath)) : null;
                }
            }


            if (this.Parameters.Filter.PageNumber > 0 && this.Parameters.Filter.PageSize > 0 && (this.Parameters.VendorId == null || this.Parameters.ServiceId == null))
            {
                int totalRecordCount;

                if (this.Parameters.ServiceId == null)
                {
                    totalRecordCount = this.Parameters.Filter.SearchText != null
                        ? filteredVendorServices.Count
                        : this.Uow.GetRepository<VendorService>()
                            .GetAll(s => s.Status && s.VendorServicePacket.VendorId == this.Parameters.VendorId)
                            .Count();
                }

                else
                {
                    totalRecordCount = this.Parameters.Filter.SearchText != null
                        ? filteredVendorServices.Count
                        : this.Uow.GetRepository<VendorService>()
                            .GetAll(s => s.Status && s.ServicePeriodPrice.ServiceId == this.Parameters.ServiceId)
                            .Count();
                }

                int totalPages = (totalRecordCount / this.Parameters.Filter.PageSize) + ((totalRecordCount % this.Parameters.Filter.PageSize) > 0 ? 1 : 0);

                output.VendorServices = new PagedUserDto<VendorServiceUserDto>()
                {
                    TotalPages = totalPages,
                    CurrentPage = this.Parameters.Filter.PageNumber,
                    Data = filteredVendorServices
                };
            }
            else
            {
                output.VendorServices = new PagedUserDto<VendorServiceUserDto>()
                {
                    Data = filteredVendorServices
                };
            }

            Result.Output = output;
        }

        #endregion
    }
}
