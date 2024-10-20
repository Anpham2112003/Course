using Application.MediaR.Comands.Account;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class CreateAccountValidation : AbstractValidator<CreateAccountRequest>
    {
        public CreateAccountValidation()
        {
            RuleFor(x=>x.Id)
                .NotEmpty();

            RuleFor(x => x.Email)
                .EmailAddress();

            RuleFor(x => x.Password)
                .Length(8, 256);

            RuleFor(x => x.FirstName)
                .Length(1, 128);

            RuleFor(x => x.LastName)
                .Length(1, 128);

        }
    }
}
