using AutoMapper;
using FluentValidation;
using JobAdvertisementWebApp.BLL.Interfaces;
using JobAdvertisementWebApp.Common.ResponseObjects;
using JobAdvertisementWebApp.DAL.Interfaces;
using JobAdvertisementWebApp.DTOs;
using JobAdvertisementWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.BLL.Services
{
    public class AdvertisementService : Service<AdvertisementListDto, AdvertisementCreateDto, AdvertisementUpdateDto, Advertisement>, IAdvertisementService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<AdvertisementCreateDto> _createDtoValidator;
        private readonly IValidator<AdvertisementUpdateDto> _updateDtoValidator;
        private readonly IApplicationService _applicationService;
        

        public AdvertisementService(IUow uow, IMapper mapper, IValidator<AdvertisementCreateDto> createDtoValidator, IValidator<AdvertisementUpdateDto> updateDtoValidator, IApplicationService applicationService) : base(uow, mapper, createDtoValidator, updateDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _applicationService = applicationService;
            
        }
        public async Task<IResponse> DisableAdvertisement(int id, int UserId)
        {
            var unchanged = await _uow.GetRepository<Advertisement>().GetByFilterAsync(x => x.Id == id);
            if (unchanged !=null)
            {
                var companyCheck = await _uow.GetRepository<Company>().GetByFilterAsync(x => x.Id == unchanged.CompanyId && x.UserId == UserId);
                if (companyCheck != null)
                {
                    var entity = await _uow.GetRepository<Advertisement>().GetByIdAsync(id);
                    entity.IsActive = false;
                    _uow.GetRepository<Advertisement>().Update(entity, unchanged);
                    await _uow.SaveChangesAsync();
                    return new Response(ResponseType.Success);
                }
                return new Response(ResponseType.NotFound);
            }
            return new Response(ResponseType.NotFound);
        }
        public async Task<IResponse> EnableAdvertisement(int id, int UserId)
        {
            var unchanged = await _uow.GetRepository<Advertisement>().GetByFilterAsync(x => x.Id == id);
            if (unchanged != null)
            {
                var companyCheck = await _uow.GetRepository<Company>().GetByFilterAsync(x => x.Id == unchanged.CompanyId && x.UserId == UserId);
                if (companyCheck != null)
                {
                    var entity = await _uow.GetRepository<Advertisement>().GetByIdAsync(id);
                    entity.IsActive = true;
                    _uow.GetRepository<Advertisement>().Update(entity, unchanged);
                    await _uow.SaveChangesAsync();
                    return new Response(ResponseType.Success);
                }
                return new Response(ResponseType.NotFound);
            }
            return new Response(ResponseType.NotFound);
        }

        public async Task<IResponse<List<AdvertisementListDto>>> GetAppliedAdvertisementAsync(List<int> idList)
        {
            List<Advertisement> advertisements = new List<Advertisement>();
            foreach (var item in idList)
            {
                advertisements.Add( await _uow.GetRepository<Advertisement>().GetByIdAsync(item));
            }
            var mapResult = _mapper.Map<List<AdvertisementListDto>>(advertisements);
            return new Response<List<AdvertisementListDto>>(mapResult, ResponseType.Success);
        }
        public async Task<IResponse<AdvertisementCreateDto>> CheckCreateAdvertisement(int CompanyId, int UserId)
        {
            var checkCompany = await _uow.GetRepository<Company>().GetByFilterAsync(x => x.Id == CompanyId && x.UserId == UserId);
            if (checkCompany != null)
            {
                AdvertisementCreateDto createDto = new();
                createDto.CompanyId = CompanyId;
                createDto.CompanyName = checkCompany.Name;
                return new Response<AdvertisementCreateDto>(createDto, ResponseType.Success);
            }
            return new Response<AdvertisementCreateDto>(ResponseType.NotFound, "Böyle bir obje bulunamadı.");
        }
        public async Task<IResponse<AdvertisementUpdateDto>> CheckUpdateAdvertisement(int id, int UserId)
        {
            var result = await _uow.GetRepository<Advertisement>().GetByIdAsync(id);
            if (result != null)
            {
                var companyCheck = await _uow.GetRepository<Company>().GetByFilterAsync(x => x.Id == result.CompanyId && x.UserId == UserId);
                if (companyCheck != null)
                {
                    var mapResult = _mapper.Map<AdvertisementUpdateDto>(result);
                    return new Response<AdvertisementUpdateDto>(mapResult, ResponseType.Success);
                }
                    return new Response<AdvertisementUpdateDto>(ResponseType.NotFound, "NotFound");
            }
            return new Response<AdvertisementUpdateDto>(ResponseType.NotFound, "NotFound");
        }
        public async Task<IResponse> DeleteAdvertisement(int id, int UserId)
        {
            var result = await _uow.GetRepository<Advertisement>().GetByIdAsync(id);
            if (result != null)
            {
                var companyCheck = await _uow.GetRepository<Company>().GetByFilterAsync(x => x.Id == result.CompanyId && x.UserId == UserId);
                if (companyCheck != null)
                {
                    var applicationIdList = await  _applicationService.GetApplicationIdListByAdvertisementId(id);
                    await _applicationService.DeleteAllApplication(applicationIdList.Data);

                    _uow.GetRepository<Advertisement>().Delete(result);
                    await _uow.SaveChangesAsync();
                    return new Response(ResponseType.Success);
                }
                return new Response(ResponseType.NotFound);
            }
            return new Response(ResponseType.NotFound);
        }
        public async Task<IResponse> DeleteAllAdvertisement(List<int> list)
        {
            foreach (var item in list)
            {
                var deletedAdvertisement = await _uow.GetRepository<Advertisement>().GetByIdAsync(item);
                _uow.GetRepository<Advertisement>().Delete(deletedAdvertisement);
                await _uow.SaveChangesAsync();
            }
            return new Response(ResponseType.Success);
        }
        public async Task<IResponse<List<int>>> GetAdvertisementIdListByCompanyId(int CompanyId)
        {
            var result = await _uow.GetRepository<Advertisement>().GetAllFilterAsync(x => x.CompanyId == CompanyId);
            List<int> advertisementIdList = new List<int>();
            if (result != null)
            {
                foreach (var item in result)
                {
                    advertisementIdList.Add(item.Id);
                }
                return new Response<List<int>>(advertisementIdList, ResponseType.Success);
            }
            return new Response<List<int>>(ResponseType.NotFound, "İlana yapılmış başvuru bulunmamaktadır.");
        }
    }
}
