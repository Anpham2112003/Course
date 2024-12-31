using Application.MediaR.Comands.Course;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class DeleteCourseValidation : AbstractValidator<DeleteCourseRequest>
    {
        public DeleteCourseValidation()
        {
            RuleFor(x=>x.Id).NotEmpty();

        }
    }
}
