using AutoMapper;
using FluentValidation;
using JobAdvertisementWebApp.BLL.Extensions;
using JobAdvertisementWebApp.BLL.Interfaces;
using JobAdvertisementWebApp.Common.ResponseObjects;
using JobAdvertisementWebApp.DAL.Interfaces;
using JobAdvertisementWebApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.BLL.Services
{
    public class Service<ListDto, CreateDto, UpdateDto, T> : IService<ListDto, CreateDto, UpdateDto, T>
        where ListDto : class, IDto, new()
        where CreateDto: class, IDto, new()
        where UpdateDto: class, IUpdateDto, new()
        where T : class, new()
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createDtoValidator;
        private readonly IValidator<UpdateDto> _updateDtoValidator;

        public Service(IUow uow, IMapper mapper, IValidator<CreateDto> createDtoValidator, IValidator<UpdateDto> updateDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<IResponse<CreateDto>> CreateAsync(CreateDto createDto)
        {
            var validationResult = _createDtoValidator.Validate(createDto);
            if (validationResult.IsValid)
            {
                var mapResult = _mapper.Map<T>(createDto);
                await _uow.GetRepository<T>().CreateAsync(mapResult);
                await _uow.SaveChangesAsync();
                return new Response<CreateDto>(createDto, ResponseType.Success);
            }
            else
            {
                return new Response<CreateDto>(createDto, ResponseType.ValidationError, validationResult.ConvertToCustomValidationError());
            }
        }

        public async Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto updateDto)
        {
            var unchangedEntity = await _uow.GetRepository<T>().GetByIdAsync(updateDto.Id);
            if (unchangedEntity != null)
            {
                var validationResult = _updateDtoValidator.Validate(updateDto);
                if (validationResult.IsValid)
                {
                    var updatedEntity = _mapper.Map<T>(updateDto);
                    _uow.GetRepository<T>().Update(updatedEntity, unchangedEntity);
                    await _uow.SaveChangesAsync();
                    return new Response<UpdateDto>(updateDto, ResponseType.Success);
                }
                else
                {
                    return new Response<UpdateDto>(updateDto, ResponseType.ValidationError, validationResult.ConvertToCustomValidationError());
                }
            }
            else
            {
                return new Response<UpdateDto>(ResponseType.NotFound, "Böyle bir entity bulunamadı.");
            }
            
        }

        public async Task<IResponse> DeleteAsync(int id)
        {
            var deletedEntity = await _uow.GetRepository<T>().GetByIdAsync(id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<T>().Delete(deletedEntity);
                await _uow.SaveChangesAsync();
                return new Response(ResponseType.Success);
            }
            else
            {
                return new Response(ResponseType.NotFound, "Böyle bir entity bulunamadı.");
            }
        }

        public async Task<IResponse<List<ListDto>>> GetAllAsync()
        {
            var result = await _uow.GetRepository<T>().GetAllAsync();
            var mapResult = _mapper.Map<List<ListDto>>(result);
            return new Response<List<ListDto>>(mapResult, ResponseType.Success);
        }

        public async Task<IResponse<List<ListDto>>> GetAllFilterAsync(Expression<Func<T,bool>> filter)
        {
            var result = await _uow.GetRepository<T>().GetAllFilterAsync(filter);
            if (result != null)
            {
                var mapResult = _mapper.Map<List<ListDto>>(result);
                return new Response<List<ListDto>>(mapResult, ResponseType.Success);
            }
            else
            {
                return new Response<List<ListDto>>(ResponseType.NotFound, "İlgili obje bulunamadı.");
            }
            
        }

        public async Task<IResponse<IDto>> GetByIdAsync<IDto>(int id)
        {
            var result = await _uow.GetRepository<T>().GetByIdAsync(id);
            var mapResult = _mapper.Map<IDto>(result);
            return new Response<IDto>(mapResult, ResponseType.Success);
        }

        public async Task<IResponse<IDto>> GetByFilterAsync<IDto>(Expression<Func<T,bool>> filter)
        {
            var result = await _uow.GetRepository<T>().GetByFilterAsync(filter);
            if (result != null)
            {
                var mapResult = _mapper.Map<IDto>(result);
                return new Response<IDto>(mapResult, ResponseType.Success);
            }
            else
            {
                return new Response<IDto>(ResponseType.NotFound, "İlgili obje bulunamadı.");
            }
            
        }
    }
}
