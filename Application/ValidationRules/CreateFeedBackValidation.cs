using Application.MediaR.Comands.FeedBack;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class CreateFeedBackValidation : AbstractValidator<CreateFeedbackRequest>
    {
        public CreateFeedBackValidation()
        {
            RuleFor(x=>x.Id).NotNull().NotEmpty();
            RuleFor(x=>x.CourseId).NotNull().NotEmpty();
            RuleFor(x => x.Rate).InclusiveBetween(1, 5);
        }
    }
}
