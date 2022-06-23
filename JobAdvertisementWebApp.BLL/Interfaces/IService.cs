using JobAdvertisementWebApp.Common.ResponseObjects;
using JobAdvertisementWebApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.BLL.Interfaces
{
    public interface IService<ListDto, CreateDto, UpdateDto, T>
        where ListDto : class, IDto, new()
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where T : class, new()
    {
        Task<IResponse<CreateDto>> CreateAsync(CreateDto createDto);
        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto updateDto);
        Task<IResponse> DeleteAsync(int id);
        Task<IResponse<List<ListDto>>> GetAllAsync();
        Task<IResponse<List<ListDto>>> GetAllFilterAsync(Expression<Func<T, bool>> filter);
        Task<IResponse<IDto>> GetByIdAsync<IDto>(int id);
        Task<IResponse<IDto>> GetByFilterAsync<IDto>(Expression<Func<T, bool>> filter);
    }
}
