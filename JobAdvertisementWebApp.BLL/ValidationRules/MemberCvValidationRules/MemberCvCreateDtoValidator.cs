using FluentValidation;
using JobAdvertisementWebApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.BLL.ValidationRules.MemberCvValidationRules
{
    public class MemberCvCreateDtoValidator : AbstractValidator<MemberCvCreateDto>
    {
        public MemberCvCreateDtoValidator()
        {
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Doğum Tarihi boş geçilemez");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres bilgisi boş geçilemez");
            RuleFor(x => x.SchoolName).NotEmpty().WithMessage("Okul bilgisi boş geçilemez");
            RuleFor(x => x.MailAddress).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon numarası boş geçilemez");
        }
    }
}
