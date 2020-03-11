using AutoMapper;
using Evanto.BL.DTOs.Admin;
using Evanto.DAL.Context;

namespace Evanto.BL.Mapping.Profiles.Admin
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<Rating, RatingDto>();
        }
    }
}
