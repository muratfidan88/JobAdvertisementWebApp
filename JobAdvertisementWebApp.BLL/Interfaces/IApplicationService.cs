using JobAdvertisementWebApp.Common.ResponseObjects;
using JobAdvertisementWebApp.DTOs;
using JobAdvertisementWebApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.BLL.Interfaces
{
    public interface IApplicationService : IService<ApplicationListDto, ApplicationCreateDto, ApplicationUpdateDto, Application>
    {
        Task<IResponse<ApplicationCreateDto>> CreateApplication(int AdvertisementId, int UserId);
        Task<IResponse<List<int>>> GetApplicationAdvertisementIdByUserId(int UserId);
        Task<IResponse<List<int>>> GetApplicationUserIdByAdvertisementId(int AdvertisementId);
        Task<IResponse> DeleteAllApplication(List<int> list);
        Task<IResponse<List<int>>> GetApplicationIdListByUserId(int UserId);
        Task<IResponse<List<int>>> GetApplicationIdListByAdvertisementId(int AdvertisementId);
        Task<IResponse<List<int>>> GetApplicationIdListByAdvertisementIdList(List<int> AdvertisementIdList);
    }
}
