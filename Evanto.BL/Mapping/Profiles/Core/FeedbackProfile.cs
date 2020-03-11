using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.BL.Operations.FeedbackOperations;
using Evanto.DAL.Context;

namespace Evanto.BL.Mapping.Profiles.Core
{
    public class FeedbackProfile : Profile
    {
        public FeedbackProfile()
        {
            CreateMap<CreateFeedbackInput, Feedback>();
            CreateMap<UpdateFeedbackInput, Feedback>();
            CreateMap<Feedback, FeedbackDto>();
            CreateMap<FeedbackDto, Feedback>();
            CreateMap<FeedbackStatusDto, FeedbackStatus>();
            CreateMap<FeedbackType, FeedbackTypeDto>();
            CreateMap<FeedbackTypeDto, FeedbackType>();
            CreateMap<FeedbackStatus, FeedbackStatusDto>().ForMember(src => src.Feedbacks, opt => opt.Ignore());
        }
    }
}
