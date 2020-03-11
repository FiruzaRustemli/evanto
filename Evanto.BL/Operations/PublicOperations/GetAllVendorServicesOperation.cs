using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Evanto.BL.DTOs.Public;
using Evanto.BL.DTOs.User;
using Evanto.BL.Operations.PaymentOperations;
using Evanto.BL.Operations.VendorServiceOperations;
using Evanto.DAL.Context;
using Evanto.Utils;
using System.Data.Entity;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.PublicOperations
{
    public class GetAllVendorServicesOperation : Operation<GetAllVendorServicesInput, GetAllVendorServicesOutput>
    {

        #region Properties

        public int DefaultPageSize => 9;

        #endregion

        #region Constructors

        #endregion

        #region Methods

        public override void DoExecute()
        {
            this.Parameters = Parameters ?? new GetAllVendorServicesInput();

            GetAllVendorServicesOutput output = new GetAllVendorServicesOutput();
            var predicate = PredicateBuilder.True<VendorService>();

            IQueryable<VendorService> query;

            if (this.Parameters.EventTypeIds != null && this.Parameters.EventTypeIds.Length > 0)
            {
                var eventServiceIds = this.Uow.GetRepository<EventService>().GetAll(e => this.Parameters.EventTypeIds.Contains(e.EventId)).Select(s => s.ServiceId).ToList();
                var serviceIds = Parameters.ServiceIds?.ToList() ?? new List<int>();
                eventServiceIds.ForEach(id => serviceIds.Add(id));
                this.Parameters.ServiceIds = serviceIds.ToArray();
            }

            if (this.Parameters.ServiceIds != null)
            {
                query = this.Uow.GetRepository<VendorService>()
                    .GetAll(predicate)
                    .Where(s => s.Status && this.Parameters.ServiceIds.Contains(s.ServicePeriodPrice.ServiceId));
            }

            else
            {
                query = this.Uow.GetRepository<VendorService>()
                    .GetAll(predicate)
                    .Where(s => s.Status);

            }

            if (this.Parameters.MinPrice != null && this.Parameters.MaxPrice != null)
            {
                query =
                    query?.Where(
                        q =>
                            q.PriceMax.Value >= this.Parameters.MinPrice && q.PriceMax.Value <= this.Parameters.MaxPrice);
            }

            if (this.Parameters.Date != null)
            {
                var requiredBookingDate = this.Parameters.Date.Value.Date;
                query = query?.Where(q => q.Booking.Count(b => DbFunctions.TruncateTime(b.BookDate) == requiredBookingDate && b.StatusId == (int)BookingStatusValue.Approved) < q.DailyQuantity);
            }

            if (this.Parameters.Filter.PageNumber > 0 && this.Parameters.Filter.PageSize > 0 && this.Parameters.Filter.PageSize < 50)
            {
                query = query?.OrderBy(a => a.Id).Skip((this.Parameters.Filter.PageNumber - 1) * this.Parameters.Filter.PageSize).Take(this.Parameters.Filter.PageSize);

            }
            else
            {
                query = query?.Take(DefaultPageSize);
            }

            if (!string.IsNullOrEmpty(this.Parameters.Filter.SearchText))
            {
                query = query?.Where(f => f.Name.Contains(this.Parameters.Filter.SearchText) || f.Description.Contains(this.Parameters.Filter.SearchText) || f.VendorServicePacket.Vendor.Name.Contains(this.Parameters.Filter.SearchText));
            }

            var filteredVendorServices = Mapper.Map<List<VendorService>, List<VendorServicePublicDto>>(query?.ToList());

            foreach (var vendorServicePublicDto in filteredVendorServices)
            {
                var vendorServicePhoto = Uow.GetRepository<File>().GetAll(p => p.ContentTypeId == 1
                                                               && p.RelationalId == vendorServicePublicDto.Id
                                                               && p.Status == true).FirstOrDefault();

                if (vendorServicePhoto != null)
                {
                    string filePath = $"{ConfigHelper.GetAppSetting("FileSavePath")}{vendorServicePhoto.Name}.{vendorServicePhoto.Extension}";
                    vendorServicePublicDto.Photo = System.IO.File.Exists(ConfigHelper.GetAppSetting("FileSaveServer") + filePath) ? Convert.ToBase64String(System.IO.File.ReadAllBytes(ConfigHelper.GetAppSetting("FileSaveServer") + filePath)) : null;
                }
            }

            int totalRecordCount = filteredVendorServices.Count();
            int totalPages;
            int currentPage;

            if (this.Parameters.Filter.PageNumber > 0 && this.Parameters.Filter.PageSize > 0)
            {
                totalPages = (totalRecordCount / this.Parameters.Filter.PageSize) + ((totalRecordCount % this.Parameters.Filter.PageSize) > 0 ? 1 : 0);
                currentPage = this.Parameters.Filter.PageNumber;
            }
            else
            {
                totalPages = (totalRecordCount / DefaultPageSize) + ((totalRecordCount % DefaultPageSize) > 0 ? 1 : 0);
                currentPage = 1;
            }

            output.VendorServices = new PagedUserDto<VendorServicePublicDto>()
            {
                CurrentPage = currentPage,
                TotalPages = totalPages,
                Data = filteredVendorServices    
            };
            Result.Output = output;
        }

        #endregion
    }
}
