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
    public class MemberCvService : Service<MemberCvListDto, MemberCvCreateDto, MemberCvUpdateDto, MemberCv>, IMemberCvService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<MemberCvCreateDto> _createDtoValidator;
        private readonly IValidator<MemberCvUpdateDto> _updateDtoValidator;
        private readonly IApplicationService _applicationService;
        public MemberCvService(IUow uow, IMapper mapper, IValidator<MemberCvCreateDto> createDtoValidator, IValidator<MemberCvUpdateDto> updateDtoValidator, IApplicationService applicationService) : base(uow, mapper, createDtoValidator, updateDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _applicationService = applicationService;
        }
        public async Task<IResponse> DeleteCV(int id, int UserId)
        {
            var checkMember = await _uow.GetRepository<MemberCv>().GetByFilterAsync(x => x.Id == id && x.UserId == UserId);
            if (checkMember != null)
            {
                var applicationIdList = await _applicationService.GetApplicationIdListByUserId(UserId);
                await _applicationService.DeleteAllApplication(applicationIdList.Data);
                _uow.GetRepository<MemberCv>().Delete(checkMember);
                await _uow.SaveChangesAsync();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound);
        }
        public async Task<IResponse<List<MemberCvListDto>>> GetMemberCVListAsync(List<int> UserIdList)
        {
            List<MemberCv> MemberCvList = new List<MemberCv>();
            foreach (var item in UserIdList)
            {
                MemberCvList.Add(await _uow.GetRepository<MemberCv>().GetByFilterAsync(x=>x.UserId==item));
            }
            var mapResult = _mapper.Map<List<MemberCvListDto>>(MemberCvList);
            return new Response<List<MemberCvListDto>>(mapResult, ResponseType.Success);
        }
    }
}
