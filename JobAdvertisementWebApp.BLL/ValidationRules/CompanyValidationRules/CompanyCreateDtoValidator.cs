using FluentValidation;
using JobAdvertisementWebApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.BLL.ValidationRules.CompanyValidationRules
{
    public class CompanyCreateDtoValidator : AbstractValidator<CompanyCreateDto>
    {
        public CompanyCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Şirket adı boş geçilemez");
            RuleFor(x => x.Defination).NotEmpty().WithMessage("Açıklama alanı boş geçilemez");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Şirket adresi boş geçilemez");
        }
    }
}
