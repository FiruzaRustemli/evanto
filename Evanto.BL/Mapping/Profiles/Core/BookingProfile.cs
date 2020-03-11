using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.BL.Operations.BookingOperations;
using Evanto.DAL.Context;

namespace Evanto.BL.Mapping.Profiles.Core
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingDto>();
            CreateMap<BookingStatus, BookingStatusDto>();
            CreateMap<CreateBookingInput, Booking>().ForMember(dest => dest.UserId,
                opt => opt.MapFrom(src => src.CurrentUserId));
        }
    }
}
