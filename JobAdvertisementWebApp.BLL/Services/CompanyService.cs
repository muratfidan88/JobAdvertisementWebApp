using AutoMapper;
using FluentValidation;
using JobAdvertisementWebApp.BLL.Interfaces;
using JobAdvertisementWebApp.Common.ResponseObjects;
using JobAdvertisementWebApp.DAL.Interfaces;
using JobAdvertisementWebApp.DTOs;
using JobAdvertisementWebApp.Entities;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.BLL.Services
{
    public class CompanyService : Service<CompanyListDto, CompanyCreateDto, CompanyUpdateDto, Company>, ICompanyService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<CompanyCreateDto> _createDtoValidator;
        private readonly IValidator<CompanyUpdateDto> _updateDtoValidator;
        private readonly IAdvertisementService _advertisementService;
        private readonly IApplicationService _applicationService;
        public CompanyService(IUow uow, IMapper mapper, IValidator<CompanyCreateDto> createDtoValidator, IValidator<CompanyUpdateDto> updateDtoValidator, IAdvertisementService advertisementService, IApplicationService applicationService) : base(uow, mapper, createDtoValidator, updateDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _advertisementService = advertisementService;
            _applicationService = applicationService;
        }
        public async Task<IResponse> DeleteCompany(int id, int UserId)
        {
            var checkResult = await _uow.GetRepository<Company>().GetByFilterAsync(x => x.Id == id && x.UserId == UserId);
            if (checkResult != null)
            {
                var advertisementIdList = await _advertisementService.GetAdvertisementIdListByCompanyId(id);
                var applicationIdList = await _applicationService.GetApplicationIdListByAdvertisementIdList(advertisementIdList.Data);

                await _applicationService.DeleteAllApplication(applicationIdList.Data);
                await _advertisementService.DeleteAllAdvertisement(advertisementIdList.Data);

                var result = await _uow.GetRepository<Company>().GetByIdAsync(id);
                _uow.GetRepository<Company>().Delete(result);
                await _uow.SaveChangesAsync();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound);
            }
           
        }

    }
}
