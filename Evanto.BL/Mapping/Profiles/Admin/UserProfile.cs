using AutoMapper;
using Evanto.BL.DTOs.Admin;
using Evanto.BL.DTOs.Core;
using Evanto.BL.Operations.BookingOperations;
using Evanto.BL.Operations.VendorOperations;
using Evanto.DAL.Context;
using UserDto = Evanto.BL.DTOs.Core.UserDto;

namespace Evanto.BL.Mapping.Profiles.Admin
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<DAL.Context.User, UserDto>();
            CreateMap<DAL.Context.User, UserAdminDto>();
            CreateMap<Gender, GenderDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<UpdateVendorInputByAdmin, DAL.Context.User>();
            CreateMap<DAL.Context.Vendor, DTOs.Admin.AdminVendorDto>();
            CreateMap<UserStatus, UserStatusDto>();
            CreateMap<UserType, UserTypeDto>();
            CreateMap<Booking, BookingAdminDto>();
            CreateMap<BookingAdminDto, Booking>();
            CreateMap<CreateBookingByAdminInput, Booking>();
            CreateMap<UserActivation, UserActivationAdminDto>();
            CreateMap<UserVerification, UserVerificationAdminDto>();
            CreateMap<UserVerificationType, UserVerificationTypeAdminDto>();


        }
    }
}
