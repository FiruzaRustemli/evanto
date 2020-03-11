using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.BL.Operations.FeedbackOperations;
using Evanto.DAL.Context;

namespace Evanto.BL.Mapping.Profiles.Admin
{
    public class ServicePeriodProfile : Profile
    {
        public ServicePeriodProfile()
        {
            CreateMap<Period, PeriodDto>();
            CreateMap<ServicePeriodPrice, ServicePeriodPriceDto>();
        }

    }
}
