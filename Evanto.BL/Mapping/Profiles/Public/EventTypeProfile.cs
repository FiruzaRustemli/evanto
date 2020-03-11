using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Evanto.BL.DTOs.Public;
using Evanto.DAL.Context;

namespace Evanto.BL.Mapping.Profiles.Public
{
    public class EventTypeProfile : Profile
    {
        public EventTypeProfile()
        {
            CreateMap<EventType, EventTypePublicDto>();
        }
    }
}
