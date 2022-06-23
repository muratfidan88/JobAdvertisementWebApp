using AutoMapper;
using JobAdvertisementWebApp.DTOs;
using JobAdvertisementWebApp.Entities;

namespace JobAdvertisementWebApp.BLL.Mapping.AutoMapper.Profiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<ApplicationListDto, Application>().ReverseMap();
            CreateMap<ApplicationCreateDto, Application>().ReverseMap();
            CreateMap<ApplicationUpdateDto, Application>().ReverseMap();
        }
    }
}
