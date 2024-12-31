using Application.MediaR.Comands.Tag;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class DeleteTagValidation:AbstractValidator<DeleteTagRequest>
    {
        public DeleteTagValidation()
        {
            RuleFor(x=>x.Id).NotEmpty();

        }
    }
}
