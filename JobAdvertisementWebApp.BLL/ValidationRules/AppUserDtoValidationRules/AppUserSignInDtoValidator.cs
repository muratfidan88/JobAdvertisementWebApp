using FluentValidation;
using JobAdvertisementWebApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.BLL.ValidationRules.AppUserDtoValidationRules
{
    public class AppUserSignInDtoValidator : AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInDtoValidator()
        {
            RuleFor(x => x.MailAddress).NotEmpty().WithMessage("Mail adresi alanı boş geçilemez.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez.");
        }
    }
}
