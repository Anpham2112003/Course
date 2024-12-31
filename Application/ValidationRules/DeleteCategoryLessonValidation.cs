using Application.MediaR.Comands.CategoryLesson;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class DeleteCategoryLessonValidation : AbstractValidator<DeleteCategoryLessonRequest>
    {
        public DeleteCategoryLessonValidation()
        {
            RuleFor(x=>x.Id).NotEmpty();
        }
    }
}
