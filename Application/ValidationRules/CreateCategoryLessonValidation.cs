using Application.MediaR.Comands.CategoryLesson;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class CreateCategoryLessonValidation : AbstractValidator<CreateCategoryLessonRequest>
    {
        public CreateCategoryLessonValidation()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Name).Length(1,128);
        }
    }
}
