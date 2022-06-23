using AutoMapper;
using JobAdvertisementWebApp.DTOs;
using JobAdvertisementWebApp.Entities;

namespace JobAdvertisementWebApp.BLL.Mapping.AutoMapper.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyListDto, Company>().ReverseMap();
            CreateMap<CompanyCreateDto, Company>().ReverseMap();
            CreateMap<CompanyUpdateDto, Company>().ReverseMap();
        }
    }
}
