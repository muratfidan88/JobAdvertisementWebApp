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
    public interface IAppUserService : IService<AppUserListDto, AppUserCreateDto, AppUserUpdateDto, AppUser>
    {
        Task<IResponse<AppUserCreateDto>> CreateEmployerAsync(AppUserCreateDto dto);
        Task<IResponse<AppUserCreateDto>> CreateMemberAsync(AppUserCreateDto dto);
        Task<IResponse<AppUserListDto>> CheckUserAsync(AppUserSignInDto dto);
    }
}
