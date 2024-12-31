using Application.MediaR.Comands.Comment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class DeleteCommentValidation : AbstractValidator<DeleteCommentRequest>
    {
        public DeleteCommentValidation()
        {
            RuleFor(x=>x.Id).NotEmpty();

        }
    }
}
