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
    public class MemberCvProfile : Profile
    {
        public MemberCvProfile()
        {
            CreateMap<MemberCvListDto, MemberCv>().ReverseMap();
            CreateMap<MemberCvCreateDto, MemberCv>().ReverseMap();
            CreateMap<MemberCvUpdateDto, MemberCv>().ReverseMap();
        }
    }
}
