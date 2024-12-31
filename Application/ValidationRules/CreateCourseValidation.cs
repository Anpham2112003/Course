using Application.MediaR.Comands.Course;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class CreateCourseValidation : AbstractValidator<CreateCourseRequest>
    {
        public CreateCourseValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
                .Length(8, 255);

            RuleFor(x => x.Price)
                .GreaterThan(1000);


        }
    }
}
