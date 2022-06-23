using AutoMapper;
using JobAdvertisementWebApp.DTOs;
using JobAdvertisementWebApp.Entities;

namespace JobAdvertisementWebApp.BLL.Mapping.AutoMapper.Profiles
{
    public class AdvertisementProfile : Profile
    {
        public AdvertisementProfile()
        {
            CreateMap<AdvertisementListDto, Advertisement>().ReverseMap();
            CreateMap<AdvertisementCreateDto, Advertisement>().ReverseMap();
            CreateMap<AdvertisementUpdateDto, Advertisement>().ReverseMap();
        }
    }
}
