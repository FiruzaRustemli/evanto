using AutoMapper;
using Evanto.BL.DTOs.Admin;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;

namespace Evanto.BL.Mapping.Profiles.Admin
{
    public class VendorServicePacketProfile : Profile
    {
        public VendorServicePacketProfile()
        {
            CreateMap<VendorServicePacket, VendorServicePacketByAdminDto>();
            CreateMap<VendorService, VendorServiceByAdminDto>();
            CreateMap<VendorServicePacketStatus, VendorServicePacketStatusByAdminDto>();
            CreateMap<PaymentStatus, PaymentStatusAdminDto> ();
            CreateMap<PaymentType, PaymentTypeAdminDto> ();
            CreateMap<Payment, PaymentAdminDto> ();
        }
    }
}
