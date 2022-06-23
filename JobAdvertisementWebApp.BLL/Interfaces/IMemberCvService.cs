using JobAdvertisementWebApp.Common.ResponseObjects;
using JobAdvertisementWebApp.DTOs;
using JobAdvertisementWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.BLL.Interfaces
{
    public interface IMemberCvService : IService<MemberCvListDto, MemberCvCreateDto, MemberCvUpdateDto, MemberCv>
    {
        Task<IResponse> DeleteCV(int id, int UserId);
        Task<IResponse<List<MemberCvListDto>>> GetMemberCVListAsync(List<int> UserIdList);
    }
}
