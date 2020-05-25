using _Nuevo.DTO.Objects.AppUserDTOs;
using FluentValidation;

namespace _Nuevo.Business.ValidationRules.FluentValidation
{
    public class AppUserSignInValidator : AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInValidator()
        {
            RuleFor(I => I.Username).NotNull().WithMessage("Kullanıcı Adı Alanı Boş Geçilemez");
            RuleFor(I => I.Password).NotNull().WithMessage("Şifre Alanı Boş Geçilemez");
        }
    }
}
