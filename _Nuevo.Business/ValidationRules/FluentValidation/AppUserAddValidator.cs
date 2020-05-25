using _Nuevo.DTO.Objects.AppUserDTOs;
using FluentValidation;

namespace _Nuevo.Business.ValidationRules.FluentValidation
{
    public class AppUserAddValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddValidator()
        {
            RuleFor(u => u.Email).NotNull().WithMessage("Email Alanı Boş Geçilemez.")
                .EmailAddress().WithMessage("Geçersiz Email Adresi.");
            RuleFor(u => u.Name).NotNull().WithMessage("İsim Alanı Boş Geçilemez.");
            RuleFor(u => u.Username).NotNull().WithMessage("Kullanıcı Adı Alanı Boş Geçilemez.");
            RuleFor(u => u.Surname).NotNull().WithMessage("Soyisim Alanı Boş Geçilemez.");
            RuleFor(u => u.Password).NotNull().WithMessage("Parola Alanı Boş Geçilemez.");
            RuleFor(u => u.ConfirmPassword).NotNull().WithMessage("Parola Onay Alanı Boş Geçilemez.");
            RuleFor(u => u.ConfirmPassword).Equal(u => u.Password).WithMessage("Parolalarınız Eşleşmiyor.");
        }
    }
}
