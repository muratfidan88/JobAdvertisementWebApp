using FluentValidation;
using JobAdvertisementWebApp.DTOs;

namespace JobAdvertisementWebApp.BLL.ValidationRules.MemberCvValidationRules
{
    public class MemberCvUpdateDtoValidator : AbstractValidator<MemberCvUpdateDto>
    {
        public MemberCvUpdateDtoValidator()
        {
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Doğum Tarihi boş geçilemez");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres bilgisi boş geçilemez");
            RuleFor(x => x.SchoolName).NotEmpty().WithMessage("Okul bilgisi boş geçilemez");
            RuleFor(x => x.MailAddress).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon numarası boş geçilemez");
        }
    }
}
