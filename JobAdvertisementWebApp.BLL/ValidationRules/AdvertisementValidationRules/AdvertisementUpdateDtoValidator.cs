using FluentValidation;
using JobAdvertisementWebApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.BLL.ValidationRules.AdvertisementValidationRules
{
    class AdvertisementUpdateDtoValidator : AbstractValidator<AdvertisementUpdateDto>
    {
        public AdvertisementUpdateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez");
            RuleFor(x => x.Defination).NotEmpty().WithMessage("Açıklama alanı boş geçilemez");
        }
    }
}
