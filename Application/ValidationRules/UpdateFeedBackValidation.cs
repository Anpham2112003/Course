using Application.MediaR.Comands.FeedBack;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class UpdateFeedBackValidation : AbstractValidator<UpdateFeedbackRequest>
    {
        public UpdateFeedBackValidation()
        {
            RuleFor(x=>x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Content).Length(1, 255);

        }
    }
}
