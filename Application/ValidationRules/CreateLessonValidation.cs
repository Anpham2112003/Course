using Application.MediaR.Comands.Lesson;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class CreateLessonValidation : AbstractValidator<CreateLessonRequest>
    {
        public CreateLessonValidation()
        {
            RuleFor(x=>x.CategoryLessonId).NotEmpty();
            RuleFor(x => x.Title).Length(1, 128);
            RuleFor(x => x.Duration).GreaterThan(0);
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x=>x.Url).Length(8,255);
        }
    }
}
