using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;
using Evanto.BL.Operations.NotificationOperations;
using Evanto.BL.Operations.RatingOperations;
using Evanto.BL.Operations.UserEventOperations;
using Evanto.BL.Operations.UserServiceOperations;
using Evanto.DAL.Context;
using Evanto.BL.Operations.UserOperations;

namespace Evanto.BL.Mapping.Profiles.User
{
    public class UserOperationProfile : Profile
    {
        public UserOperationProfile()
        {
            CreateMap<CreateRatingInput, Rating>().ForMember(dest => dest.UserId,
                opt => opt.MapFrom(src => src.CurrentUserId))
                .ForMember(dest => dest.Value,
                opt => opt.MapFrom(src => src.Rating));

            CreateMap<CreateUserSettingsInput, UserSetting>().ForMember(dest => dest.UserId,
                opt => opt.MapFrom(src => src.CurrentUserId));

            CreateMap<UpdateUserSettingsInput, UserSetting>().ForMember(dest => dest.UserId,
                opt => opt.MapFrom(src => src.CurrentUserId));

            CreateMap<CreateUserInput, DAL.Context.User>();

            CreateMap<UserEvent, UserEventUserDto>();

            CreateMap<UserService, UserServiceUserDto>();

            CreateMap<UserService, UserServiceForBookingUserDto>();

            CreateMap<VendorService, VendorServiceUserDto>().ForMember(dist => dist.RatedUserCount, opt => opt.MapFrom(src => src.Rating1.Count)); ;
            CreateMap<VendorService, BookingVendorServiceUserDto>().ForMember(dist => dist.RatedUserCount, opt => opt.MapFrom(src => src.Rating1.Count)); ;

            CreateMap<ServicePeriodPrice, ServicePeriodPriceUserDto>();

            CreateMap<VendorServicePacket, VendorServicePacketUserDto>();

            CreateMap<Service, ServiceUserDto>();

            CreateMap<DAL.Context.Vendor, VendorUserDto>();

            CreateMap<DAL.Context.User, UserUserDto>();

            CreateMap<Booking, BookingUserDto>();

            CreateMap<EventService, EventServiceUserDto>();

            CreateMap<DAL.Context.User, UserUserDto>();

            CreateMap<DAL.Context.User, VendorUserUserDto>();

            CreateMap<CreateUserServiceByUserInput, UserService>().ForMember(dest => dest.UserId,
                opt => opt.MapFrom(src => src.CurrentUserId));

            CreateMap<UpdateGeneralInfoByUserUserInput, DAL.Context.User>().ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.CurrentUserId));

            CreateMap<UpdateAdditionalInfoByUserUserInput, DAL.Context.User>().ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.CurrentUserId)); ;

            CreateMap<CreateUserEventByUserInput, UserEvent>().ForMember(dest => dest.UserId,
                opt => opt.MapFrom(src => src.CurrentUserId)); ;


            CreateMap<Gender, GenderUserDto>();

            CreateMap<EventType, EventTypeUserDto>();


            CreateMap<CreateBookingNotificationByUserInput, Notification>();
        }
    }
}
