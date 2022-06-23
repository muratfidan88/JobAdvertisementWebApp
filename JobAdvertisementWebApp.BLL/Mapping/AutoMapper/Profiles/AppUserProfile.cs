using AutoMapper;
using JobAdvertisementWebApp.DTOs;
using JobAdvertisementWebApp.Entities;

namespace JobAdvertisementWebApp.BLL.Mapping.AutoMapper.Profiles
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUserListDto, AppUser>().ReverseMap();
            CreateMap<AppUserUpdateDto, AppUser>().ReverseMap();
            CreateMap<AppUserCreateDto, AppUser>().ReverseMap();
        }
    }
}
