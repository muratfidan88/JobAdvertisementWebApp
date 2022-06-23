using FluentValidation;
using JobAdvertisementWebApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.BLL.ValidationRules.ApplicationValidationRules
{
    public class ApplicationCreateDtoValidator : AbstractValidator<ApplicationCreateDto>
    {
        public ApplicationCreateDtoValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.AdvertisementId).NotEmpty();
        }
    }
}
