using FluentValidation;
using JobAdvertisementWebApp.DTOs;

namespace JobAdvertisementWebApp.BLL.ValidationRules.AppUserDtoValidationRules
{
    class AppUserUpdateDtoValidator : AbstractValidator<AppUserUpdateDto>
    {
        public AppUserUpdateDtoValidator()
        {
            RuleFor(x => x.MailAddress).NotEmpty().WithMessage("Mail adresi alanı boş geçilemez.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad alanı boş geçilemez.");
        }
    }
}
