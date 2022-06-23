using FluentValidation;
using JobAdvertisementWebApp.DTOs;

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
