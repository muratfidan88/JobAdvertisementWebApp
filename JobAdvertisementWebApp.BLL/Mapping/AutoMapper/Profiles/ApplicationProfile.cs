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
