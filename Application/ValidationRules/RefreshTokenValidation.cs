using Application.MediaR.Comands.Account;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class RefreshTokenValidation : AbstractValidator<RefreshTokenRequest>
    {
        public RefreshTokenValidation()
        {
            RuleFor(x => x.Refreshtoken)
                .NotEmpty();
        }
    }
}
