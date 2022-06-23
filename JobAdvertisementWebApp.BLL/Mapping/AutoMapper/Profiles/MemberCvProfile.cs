using AutoMapper;
using JobAdvertisementWebApp.DTOs;
using JobAdvertisementWebApp.Entities;

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
