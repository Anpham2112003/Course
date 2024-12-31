using Application.MediaR.Comands.Topic;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class DeleteTopicInCourseValidationa : AbstractValidator<DeleteTopicCourseRequest>
    {
        public DeleteTopicInCourseValidationa()
        {
            RuleFor(x=>x.TopicId).NotNull().NotEmpty();
            RuleFor(x=> x.CourseId).NotEmpty().NotNull();
        }
    }
}
