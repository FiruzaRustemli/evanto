using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.BL.Operations.ServiceOperations;
using Evanto.BL.Operations.ServicePeriodOperations;
using Evanto.BL.Operations.ServicePeriodPriceOperations;
using Evanto.BL.Operations.UserServiceOperations;
using Evanto.DAL.Context;

namespace Evanto.BL.Mapping.Profiles.Core
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<CreateServiceInput, Service>();
            CreateMap<Service, ServiceDto>();
            
            CreateMap<CreateServicePeriodInput, Period>();
            CreateMap<UpdateServicePeriodInput, Period>();

            CreateMap<CreateServicePeriodPriceInput, ServicePeriodPrice>();
            CreateMap<ServicePeriodPrice, ServicePeriodPriceDto>().ForMember(dest => dest.VendorServices,
                opt => opt.MapFrom(src => src.VendorService));

            CreateMap<UpdateServicePeriodPriceInput, ServicePeriodPrice>();
            CreateMap<UpdateUserServiceInput, UserService>();
            CreateMap<Period, PeriodDto>().ForMember(dest => dest.ServicePeriodPrices, opt => opt.MapFrom(src => src.ServicePeriodPrice));
        }
    }
}
