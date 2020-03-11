using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Evanto.BL.DTOs.Vendor;
using Evanto.DAL.Context;
using Evanto.BL.Operations.VendorOperations;
using Evanto.BL.Operations.BookingOperations;
using Evanto.BL.Operations.NotificationOperations;

namespace Evanto.BL.Mapping.Profiles.Vendor
{
    public class VendorOperationProfile : Profile
    {
        public VendorOperationProfile()
        {
            CreateMap<Period, PeriodVendorDto>();
            CreateMap<ServicePeriodPrice, ServicePeriodPriceVendorDto>();
            CreateMap<Service, ServiceVendorDto>();
            CreateMap<VendorService, VendorServiceVendorDto>();
            CreateMap<DAL.Context.Vendor, VendorVendorDto>();
            CreateMap<DAL.Context.User, UserVendorDto>();
            CreateMap<DAL.Context.User, UpdateVendorContactInformationsInput>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username));
            CreateMap<UpdateVendorContactInformationsInput, DAL.Context.User>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username));
            CreateMap<VendorServicePacket, VendorServicePacketVendorDto>();                
            CreateMap<VendorServicePacketStatus, VendorServicePacketStatusVendorDto>();
            CreateMap<CreateBookingNotificationByVendorInput, Notification>();

            CreateMap<File, FileVendorDto>();
            CreateMap<FileType, FileTypeVendorDto>();
            CreateMap<ContentType, ContentTypeVendorDto>();
            CreateMap<Booking, BookingVendorDto>();
            CreateMap<CreateBookingByVendorInput, Booking>();
        }
    }
}
