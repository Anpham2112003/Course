using Application.MediaR.Comands.Tag;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class UpdateTagValidation : AbstractValidator<UpdateTagRequest>
    {
        public UpdateTagValidation()
        {
            RuleFor(x=>x.Id).NotEmpty();

            RuleFor(x=>x.Name).Length(1,30);
        }
    }
}
