using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.BL.Operations.VendorOperations;
using Evanto.BL.Operations.VendorServiceExceptionalEventOperations;
using Evanto.DAL.Context;
using Evanto.BL.DTOs.Vendor;

namespace Evanto.BL.Mapping.Profiles.Core
{
    public class VendorProfile : Profile
    {
        public VendorProfile()
        {
            CreateMap<CreateVendorInput, DAL.Context.Vendor>();
            CreateMap<DAL.Context.Vendor, VendorDto>();
            CreateMap<ContactInformationVendorDto, DAL.Context.Vendor>();
            CreateMap<DAL.Context.Vendor, ContactInformationVendorDto > ();

            CreateMap<CreateVendorServiceExceptionalEventInput, VendorServiceExceptionalEvent>();
            CreateMap<VendorServiceExceptionalEvent, VendorServiceExceptionalEventDto>();
            CreateMap<VendorServicePacket, VendorServicePacketDto>();
            CreateMap<VendorService, VendorServiceDto>()
                .ForMember(dest => dest.VendorServiceExceptionalEvents, opt => opt.MapFrom(src => src.VendorServiceExceptionalEvent));
        }
    }
}
