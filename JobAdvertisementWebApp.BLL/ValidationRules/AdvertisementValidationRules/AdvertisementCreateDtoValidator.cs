using FluentValidation;
using JobAdvertisementWebApp.DTOs;

namespace JobAdvertisementWebApp.BLL.ValidationRules.AdvertisementValidationRules
{
    public class AdvertisementCreateDtoValidator : AbstractValidator<AdvertisementCreateDto>
    {
        public AdvertisementCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez");
            RuleFor(x => x.Defination).NotEmpty().WithMessage("Açıklama alanı boş geçilemez");
        }
    }
}
