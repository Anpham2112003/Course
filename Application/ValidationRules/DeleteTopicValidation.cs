using Application.MediaR.Comands.Topic;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class DeleteTopicValidation : AbstractValidator<DeleteTopicRequest>
    {
        public DeleteTopicValidation()
        {
            RuleFor(x=>x.Id).NotNull().NotEmpty();
        }
    }
}
