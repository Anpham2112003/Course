using Application.MediaR.Comands.Account;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class DeleteAccountValidation : AbstractValidator<DeleteAccountRequest>
    {
        public DeleteAccountValidation()
        {
            RuleFor(x => x.Email)
                .EmailAddress();

            RuleFor(x => x.Password)
                .Length(8, 256);

        }
    }
}
