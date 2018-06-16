using System;
using System.Linq;
using Dating.API.Dtos;
using Dating.API.Entities;
using Profile = AutoMapper.Profile;

namespace Dating.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, ProfilesToReturnDto>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Profile.City))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Profile.Country))
                .ForMember(dest => dest.PhotoUrl,
                    opt => opt.MapFrom(src => src.Profile.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.Age,
                    opt => opt.ResolveUsing(d => (DateTime.Now - d.DateOfBirth).TotalDays / 365));

            CreateMap<User, ProfileToReturnForDetailDto>()
                .ForMember(dest => dest.Age, 
                    opt => opt.ResolveUsing(d => (DateTime.Now - d.DateOfBirth).TotalDays / 365))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Profile.City))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Profile.Country))
                .ForMember(dest => dest.PhotoUrl,
                    opt => opt.MapFrom(src => src.Profile.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Profile.Description))
                .ForMember(dest => dest.LookingFor, opt => opt.MapFrom(src => src.Profile.LookingFor))
                .ForMember(dest => dest.LastActive, opt => opt.MapFrom(src => src.Profile.LastActive))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Profile.Created))
                .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Profile.Photos))
                .ForMember(dest => dest.Interests, opt => opt.MapFrom(src => src.Profile.Interests));

            CreateMap<ProfileForUpdateDto, Entities.Profile>();

            CreateMap<Photo, PhotoDto>();
        }
    }
}