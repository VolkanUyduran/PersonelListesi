using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
    public class PersonelValidator:AbstractValidator<Personel>
    {
        public PersonelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Personel Adını Boş geçemezsiniz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Personel Soyadını Boş geçemezsiniz");
            RuleFor(x => x.Tel).NotEmpty().WithMessage("Personel Telefon numarasını Boş geçemezsiniz");
        }
    }
}
