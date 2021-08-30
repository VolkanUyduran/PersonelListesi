using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
   public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(x => x.Personels.Count).GreaterThan(0).WithMessage("Bu Departmanda Personel olduğu için silme işlemi yapamazsınız.");
        }
    }
}