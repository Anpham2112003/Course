using Application.MediaR.Comands.Topic;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class UpdateTopicValidation : AbstractValidator<UpdateTopicRequest>
    {
        public UpdateTopicValidation()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x=>x.Name).NotNull()
                .NotEmpty();

        }
    }
}
