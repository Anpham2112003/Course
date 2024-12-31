using Application.MediaR.Comands.Cart;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class CreateCartValidation : AbstractValidator<CreateCartRequest>
    {
        public CreateCartValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x=>x.CourseId).NotEmpty();
           
        }
    }
}
