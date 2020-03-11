using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Mapping.Profiles.Core
{
    public class FileProfile: Profile
    {
        public FileProfile()
        {
            CreateMap<File, FileDto>();
            CreateMap<FileType, FileTypeDto>();
            CreateMap<ContentType, ContentTypeDto>();
        }
    }
}
