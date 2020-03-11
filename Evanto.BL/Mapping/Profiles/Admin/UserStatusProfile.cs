using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.BL.Operations.FeedbackOperations;
using Evanto.BL.Operations.UserStatusOperations;
using Evanto.BL.Operations.UserTypeOperations;
using Evanto.DAL.Context;

namespace Evanto.BL.Mapping.Profiles.Admin
{
    public class UserStatusProfile : Profile
    {
        public UserStatusProfile()
        {
            CreateMap<UpdateUserStatusInput, UserStatus>();
            CreateMap<CreateUserStatusInput, UserStatus>();
        }

    }
}
