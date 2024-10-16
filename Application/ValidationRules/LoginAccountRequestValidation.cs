using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.MediaR.Comands.Account;

namespace Application.ValidationRules
{
    public class LoginAccountRequestValidation:AbstractValidator<LoginAccountRequest>
    {
        public LoginAccountRequestValidation()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .EmailAddress();

            RuleFor(x => x.Password)
                .Length(8, 255);
            
        }
    }
}
