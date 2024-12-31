using Application.MediaR.Comands.Topic;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class AddTopicToCourseValidation : AbstractValidator<AddTopicToCourseRequest>
    {
        public AddTopicToCourseValidation()
        {
            RuleFor(x=>x.CourseId).NotNull().NotEmpty();
            RuleFor(x=>x.TopicId).NotEmpty().NotNull();
        }
    }
}
