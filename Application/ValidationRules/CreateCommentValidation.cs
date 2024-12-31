using Application.MediaR.Comands.Comment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class CreateCommentValidation : AbstractValidator<CreateCommentRequest>
    {
        public CreateCommentValidation()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x=>x.LessonId).NotEmpty();
            RuleFor(x=>x.Content).Length(1,255);
            
        }
    }
}
