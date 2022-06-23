using AutoMapper;
using FluentValidation;
using JobAdvertisementWebApp.BLL.Interfaces;
using JobAdvertisementWebApp.Common.ResponseObjects;
using JobAdvertisementWebApp.DAL.Interfaces;
using JobAdvertisementWebApp.DTOs;
using JobAdvertisementWebApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.BLL.Services
{
    public class ApplicationService : Service<ApplicationListDto, ApplicationCreateDto, ApplicationUpdateDto, Application>, IApplicationService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<ApplicationCreateDto> _createDtoValidator;
        private readonly IValidator<ApplicationUpdateDto> _updateDtoValidator;

        public ApplicationService(IUow uow, IMapper mapper, IValidator<ApplicationCreateDto> createDtoValidator, IValidator<ApplicationUpdateDto> updateDtoValidator) : base(uow, mapper, createDtoValidator, updateDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }
        public async Task<IResponse<ApplicationCreateDto>> CreateApplication(int AdvertisementId, int UserId)
        {
            var result = await _uow.GetRepository<Application>().GetByFilterAsync(x => x.UserId == UserId && x.AdvertisementId == AdvertisementId);
            if (result == null)
            {
                Application app = new Application();
                app.AdvertisementId = AdvertisementId;
                app.UserId = UserId;
                await _uow.GetRepository<Application>().CreateAsync(app);
                await _uow.SaveChangesAsync();
                var dto = _mapper.Map<ApplicationCreateDto>(app);
                return new Response<ApplicationCreateDto>(dto, ResponseType.Success);
            }
            else
            {
                List<CustomValidationError> errors = new List<CustomValidationError>()
                {
                    new CustomValidationError()
                    {
                        ErrorMessage="Bu ilana daha önceden başvuru yapılmış.",
                        PropertyName=""
                        
                    }
                };
                return new Response<ApplicationCreateDto>(new ApplicationCreateDto(), ResponseType.ValidationError, errors);
            }
        }
        public async Task<IResponse<List<int>>> GetApplicationAdvertisementIdByUserId(int UserId)
        {
            var result = await _uow.GetRepository<Application>().GetAllFilterAsync(x => x.UserId == UserId);
            List<int> AdvertisementIdList = new List<int>();
            if (result != null)
            {
                foreach (var item in result)
                {
                    AdvertisementIdList.Add(item.AdvertisementId);
                }
                return new Response<List<int>>(AdvertisementIdList, ResponseType.Success);
            }
            else
            {
                return new Response<List<int>>(ResponseType.NotFound, "Henüz bir başvurunuz bulunmamaktadır.");
            }
        }
        public async Task<IResponse<List<int>>> GetApplicationUserIdByAdvertisementId(int AdvertisementId)
        {
            var result = await _uow.GetRepository<Application>().GetAllFilterAsync(x => x.AdvertisementId == AdvertisementId);
            List<int> UserIdList = new List<int>();
            if (result != null)
            {
                foreach (var item in result)
                {
                    UserIdList.Add(item.UserId);
                }
                return new Response<List<int>>(UserIdList, ResponseType.Success);
            }
            else
            {
                return new Response<List<int>>(ResponseType.NotFound, "İlana yapılmış başvuru bulunmamaktadır.");
            }
        }
        public async Task<IResponse> DeleteAllApplication(List<int> list)
        {
            foreach (var item in list)
            {
                var deletedApplication = await _uow.GetRepository<Application>().GetByIdAsync(item);
                _uow.GetRepository<Application>().Delete(deletedApplication);
                await _uow.SaveChangesAsync();
            }
            return new Response(ResponseType.Success);
        }
        public async Task<IResponse<List<int>>> GetApplicationIdListByUserId(int UserId)
        {
            var result = await _uow.GetRepository<Application>().GetAllFilterAsync(x => x.UserId == UserId);
            List<int> applicationIdList = new List<int>();
            if (result != null)
            {
                foreach (var item in result)
                {
                    applicationIdList.Add(item.Id);
                }
                return new Response<List<int>>(applicationIdList, ResponseType.Success);
            }
            else
            {
                return new Response<List<int>>(ResponseType.NotFound, "İlana yapılmış başvuru bulunmamaktadır.");
            }
        }
        public async Task<IResponse<List<int>>> GetApplicationIdListByAdvertisementId(int AdvertisementId)
        {
            var result = await _uow.GetRepository<Application>().GetAllFilterAsync(x => x.AdvertisementId == AdvertisementId);
            List<int> applicationIdList = new List<int>();
            if (result != null)
            {
                foreach (var item in result)
                {
                    applicationIdList.Add(item.Id);
                }
                return new Response<List<int>>(applicationIdList, ResponseType.Success);
            }
            else
            {
                return new Response<List<int>>(ResponseType.NotFound, "İlana yapılmış başvuru bulunmamaktadır.");
            }
        }
        public async Task<IResponse<List<int>>> GetApplicationIdListByAdvertisementIdList(List<int> AdvertisementIdList)
        {
            List<int> applicationIdList = new List<int>();
            foreach (var advertisementId in AdvertisementIdList)
            {
                var result = await _uow.GetRepository<Application>().GetAllFilterAsync(x => x.AdvertisementId == advertisementId);
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        applicationIdList.Add(item.Id);
                    }
                }
            }
            return new Response<List<int>>(applicationIdList, ResponseType.Success);
           
        }
    }
}
