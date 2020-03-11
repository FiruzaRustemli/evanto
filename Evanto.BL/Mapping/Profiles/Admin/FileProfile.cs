using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.BL.Operations.DiscountCouponOperations;
using Evanto.BL.Operations.FileOperations;
using Evanto.BL.Operations.RoleOperations;
using Evanto.BL.Operations.UserActivationOperations;
using Evanto.BL.Operations.UserEventOperations;
using Evanto.BL.Operations.UserOperations;
using Evanto.BL.Operations.UserStatusOperations;
using Evanto.BL.Operations.UserTypeOperations;
using Evanto.DAL.Context;
using UserDto = Evanto.BL.DTOs.Core.UserDto;

namespace Evanto.BL.Mapping.Profiles.Admin
{
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<CreateImageInput, CreateFileInput>();
        }
    }
}
