using Application.MediaR.Comands.Comment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class UpdateCommentValidation : AbstractValidator<UpdateCommentRequest>
    {
        public UpdateCommentValidation()
        {
            RuleFor(x=>x.Id).NotEmpty();

            RuleFor(x=>x.Content).Length(1,255);

           
        }
    }
}
