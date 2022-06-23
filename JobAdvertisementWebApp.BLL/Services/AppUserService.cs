using AutoMapper;
using FluentValidation;
using JobAdvertisementWebApp.BLL.Extensions;
using JobAdvertisementWebApp.BLL.Interfaces;
using JobAdvertisementWebApp.Common.ResponseObjects;
using JobAdvertisementWebApp.DAL.Interfaces;
using JobAdvertisementWebApp.DTOs;
using JobAdvertisementWebApp.Entities;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.BLL.Services
{
    public class AppUserService : Service<AppUserListDto, AppUserCreateDto, AppUserUpdateDto, AppUser>, IAppUserService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUserCreateDto> _createDtoValidator;
        private readonly IValidator<AppUserUpdateDto> _updateDtoValidator;
        private readonly IValidator<AppUserSignInDto> _signInDtoValidator;

        public AppUserService(IUow uow, IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IValidator<AppUserSignInDto> signInDtoValidator):base(uow, mapper, createDtoValidator, updateDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _signInDtoValidator = signInDtoValidator;
        }

        public async Task<IResponse<AppUserCreateDto>> CreateEmployerAsync(AppUserCreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var userResult = await _uow.GetRepository<AppUser>().GetByFilterAsync(x => x.MailAddress == dto.MailAddress);
                if (userResult == null)
                {
                    var result = _mapper.Map<AppUser>(dto);
                    result.RoleId = 1;
                    await _uow.GetRepository<AppUser>().CreateAsync(result);
                    await _uow.SaveChangesAsync();
                    return new Response<AppUserCreateDto>(dto, ResponseType.Success);

                }
                else
                {
                    return new Response<AppUserCreateDto>(ResponseType.Error, "Bu mail adresi ile daha öncesinden kayıt olunmuş.");
                }
            }
            else
            {
                return new Response<AppUserCreateDto>(dto, ResponseType.ValidationError, validationResult.ConvertToCustomValidationError());
            }
            
        }

        public async Task<IResponse<AppUserCreateDto>> CreateMemberAsync(AppUserCreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var userResult = await _uow.GetRepository<AppUser>().GetByFilterAsync(x => x.MailAddress == dto.MailAddress);
                if (userResult == null)
                {
                    var result = _mapper.Map<AppUser>(dto);
                    result.RoleId = 2;
                    await _uow.GetRepository<AppUser>().CreateAsync(result);
                    await _uow.SaveChangesAsync();
                    return new Response<AppUserCreateDto>(dto, ResponseType.Success);

                }
                else
                {
                    return new Response<AppUserCreateDto>(ResponseType.Error, "Bu mail adresi ile daha öncesinden kayıt olunmuş.");
                }
            }
            else
            {
                return new Response<AppUserCreateDto>(dto, ResponseType.ValidationError, validationResult.ConvertToCustomValidationError());
            }
        }

        public async Task<IResponse<AppUserListDto>> CheckUserAsync(AppUserSignInDto dto)
        {
            var validationResult = _signInDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var userResult = await _uow.GetRepository<AppUser>().GetByFilterAsync(x => x.MailAddress == dto.MailAddress && x.Password == dto.Password);
                if (userResult != null)
                {
                    var result = _mapper.Map<AppUserListDto>(userResult);
                    return new Response<AppUserListDto>(result, ResponseType.Success);
                }
                else
                {
                    return new Response<AppUserListDto>(ResponseType.Error, "Kullanıcı adı veya şifre hatalı");
                }
            }
            else
            {
                return new Response<AppUserListDto>(ResponseType.NotFound, "Lütfen ilgili alanları doldurunuz.");
            }
        }
    }
}
