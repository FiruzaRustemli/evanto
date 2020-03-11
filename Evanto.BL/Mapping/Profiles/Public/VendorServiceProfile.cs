using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Evanto.BL.DTOs.Public;
using Evanto.DAL.Context;

namespace Evanto.BL.Mapping.Profiles.Public
{
    public class VendorServiceProfile : Profile
    {
        public VendorServiceProfile()
        {
            CreateMap<VendorService, VendorServicePublicDto>().ForMember(dist => dist.RatedUserCount, opt => opt.MapFrom(src => src.Rating1.Count));
        }
    }
}
