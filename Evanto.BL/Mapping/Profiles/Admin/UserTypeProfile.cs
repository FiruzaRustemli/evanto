using AutoMapper;
using Evanto.BL.DTOs.Admin;
using Evanto.BL.DTOs.Core;
using Evanto.BL.Operations.UserTypeOperations;
using Evanto.DAL.Context;

namespace Evanto.BL.Mapping.Profiles.Admin
{
    public class UserTypeProfile : Profile
    {
        public UserTypeProfile()
        {
            CreateMap<UserType, UserTypeDto>();
            CreateMap<UserType, UserTypeAdminDto>();
            CreateMap<UpdateUserTypeInput, UserType>();
        }

    }
}
