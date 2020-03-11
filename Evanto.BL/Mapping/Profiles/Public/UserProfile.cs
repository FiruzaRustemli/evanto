using AutoMapper;
using Evanto.BL.DTOs.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Mapping.Profiles.Public
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<DAL.Context.User, UserPublicDto>();
        }
    }
}
