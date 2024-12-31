using Application.MediaR.Comands.Cart;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class DeleteCartValidation : AbstractValidator<DeleteCartRequest>
    {
        public DeleteCartValidation()
        {
            RuleFor(x=>x.Id).NotEmpty();
        }
    }
}
