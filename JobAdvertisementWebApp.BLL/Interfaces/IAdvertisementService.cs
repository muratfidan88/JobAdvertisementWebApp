using JobAdvertisementWebApp.Common.ResponseObjects;
using JobAdvertisementWebApp.DTOs;
using JobAdvertisementWebApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.BLL.Interfaces
{
    public interface IAdvertisementService : IService<AdvertisementListDto,AdvertisementCreateDto, AdvertisementUpdateDto, Advertisement>
    {
        Task<IResponse> DisableAdvertisement(int id, int UserId);
        Task<IResponse> EnableAdvertisement(int id, int UserId);
        Task<IResponse<List<AdvertisementListDto>>> GetAppliedAdvertisementAsync(List<int> idList);
        Task<IResponse> DeleteAllAdvertisement(List<int> list);
        Task<IResponse<List<int>>> GetAdvertisementIdListByCompanyId(int CompanyId);
        Task<IResponse> DeleteAdvertisement(int id, int UserId);
        Task<IResponse<AdvertisementUpdateDto>> CheckUpdateAdvertisement(int id, int UserId);
        Task<IResponse<AdvertisementCreateDto>> CheckCreateAdvertisement(int CompanyId, int UserId);
    }
}
