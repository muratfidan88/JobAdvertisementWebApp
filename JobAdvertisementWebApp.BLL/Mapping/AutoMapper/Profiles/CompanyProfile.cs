using AutoMapper;
using JobAdvertisementWebApp.DTOs;
using JobAdvertisementWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
