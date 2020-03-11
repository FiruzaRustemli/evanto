using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.BL.Operations.EventTypeOperations;
using Evanto.DAL.Context;

namespace Evanto.BL.Mapping.Profiles.Core
{
    public class EventProfile: Profile
    { 
        public EventProfile()
        {
            CreateMap<EventType, EventTypeDto>();
            CreateMap<CreateEventTypeInput, EventType>();
        }
    }
}
