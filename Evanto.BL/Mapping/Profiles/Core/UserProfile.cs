using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.BL.Operations.RoleOperations;
using Evanto.BL.Operations.UserActivationOperations;
using Evanto.BL.Operations.UserEventOperations;
using Evanto.BL.Operations.UserOperations;
using Evanto.BL.Operations.UserStatusOperations;
using Evanto.BL.Operations.UserTypeOperations;
using Evanto.DAL.Context;

namespace Evanto.BL.Mapping.Profiles.Core
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<DAL.Context.User, UserDto>();

            CreateMap<Role, RoleDto>();
            CreateMap<CreateRoleInput, Role>();
            CreateMap<UpdateRoleInput, Role>();
            CreateMap<GenderDto, Gender>();
            CreateMap<Gender, GenderDto>();
            CreateMap<UserStatus, UserStatusDto>();

            CreateMap<CreateUserActivationInput, UserActivation>();
            CreateMap<UserActivation, UserActivationDto>();

            CreateMap<CreateUserEventInput, UserEvent>();
            CreateMap<CreateUserInput, DAL.Context.User>();

            CreateMap<ResetPasswordbyAdminUserInput, DAL.Context.User>();
            CreateMap<CreateUserStatusInput, UserStatus>();

            CreateMap<UpdateUserStatusInput, UserStatus>();
            CreateMap<CreateUserTypeInput, UserType>();
            CreateMap<UpdateUserTypeInput, UserType>();

            CreateMap<DAL.Context.User, UserValidationDto>();
        }
    }
}
