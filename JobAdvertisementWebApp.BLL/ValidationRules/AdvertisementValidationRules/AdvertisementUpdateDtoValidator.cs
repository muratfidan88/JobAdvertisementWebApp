using FluentValidation;
using JobAdvertisementWebApp.DTOs;

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
