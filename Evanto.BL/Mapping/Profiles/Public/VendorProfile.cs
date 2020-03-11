using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Evanto.BL.DTOs.Public;

namespace Evanto.BL.Mapping.Profiles.Public
{
    public class VendorProfile : Profile
    {
        public VendorProfile()
        {
            CreateMap<DAL.Context.Vendor, VendorPublicDto>();
        }
    }
}
