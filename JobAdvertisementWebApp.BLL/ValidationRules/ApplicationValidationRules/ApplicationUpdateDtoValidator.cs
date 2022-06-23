using FluentValidation;
using JobAdvertisementWebApp.DTOs;

namespace JobAdvertisementWebApp.BLL.ValidationRules.ApplicationValidationRules
{
    public class ApplicationUpdateDtoValidator : AbstractValidator<ApplicationUpdateDto>
    {
        public ApplicationUpdateDtoValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.AdvertisementId).NotEmpty();
        }
    }
}
