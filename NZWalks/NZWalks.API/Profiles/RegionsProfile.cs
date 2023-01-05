using AutoMapper;
using NZWalks.API.DTOs;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Profiles
{
    public class RegionsProfile : Profile
    {
        public RegionsProfile() 
        {
            CreateMap<Region, RegionDto>()
                .ReverseMap();
        }
    }
}
