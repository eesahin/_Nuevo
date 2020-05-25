using _Nuevo.DTO.Objects.TagetDTOs;
using FluentValidation;

namespace _Nuevo.Business.ValidationRules.FluentValidation
{
    public class TargetUpdateValidator : AbstractValidator<TargetUpdateDto>
    {
        public TargetUpdateValidator()
        {
            RuleFor(u => u.Url).NotNull().WithMessage("Url Alanı Boş Geçilemez.");
            RuleFor(u => u.Name).NotNull().WithMessage("İsim Alanı Boş Geçilemez.");
        }
    }
}
