using _Nuevo.DTO.Objects.TagetDTOs;
using FluentValidation;

namespace _Nuevo.Business.ValidationRules.FluentValidation
{
    public class TargetAddValidator : AbstractValidator<TargetAddDto>
    {
        public TargetAddValidator()
        {
            RuleFor(u => u.Url).NotNull().WithMessage("Url Alanı Boş Geçilemez.");
            RuleFor(u => u.Name).NotNull().WithMessage("İsim Alanı Boş Geçilemez.");
        }
    }
}
