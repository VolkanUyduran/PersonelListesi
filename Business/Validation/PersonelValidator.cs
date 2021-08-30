using Entities.Concrete;
using FluentValidation;

namespace Business.Validation
{
    public class PersonelValidator:AbstractValidator<Personel>
    {
        public PersonelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Personel Adını Boş geçemezsiniz");
            RuleFor(x => x.Surname).NotEmpty().NotNull().WithMessage("Personel Soyadını Boş geçemezsiniz");
            RuleFor(x => x.Tel).NotEmpty().NotNull().WithMessage("Personel Telefon numarasını Boş geçemezsiniz");
        }
    }
}
