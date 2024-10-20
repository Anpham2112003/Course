using Application.MediaR.Comands.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class UpdateProfileUserValidation : AbstractValidator<UpdateProfileUserRequest>
    {
        public UpdateProfileUserValidation()
        {
            RuleFor(x => x.FirstName)
                .Length(1, 128);

            RuleFor(x => x.LastName)
                .Length(1, 128);

            RuleFor(x => x.FullName)
                .Length(8, 256);

        }
    }
}
