using Application.MediaR.Comands.Account;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class ResetPasswordValidation : AbstractValidator<ResetPasswordRequest>
    {
        public ResetPasswordValidation()
        {
            RuleFor(x => x.Email)
                .EmailAddress();

            RuleFor(x => x.OldPassword)
                .Length(8, 256);

            RuleFor(x => x.NewPassword)
                .Length(8, 256);
        }
    }
}
