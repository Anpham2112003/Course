using Application.MediaR.Pipeline;
using Domain.Types.ErrorTypes.Unions.Comment;
using Domain.Untils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Comment
{
    public class UpdateCommentRequest:IRequest<MutationPayload<UpdateCommentRequest,UpdateCommentError>>,IRequireValidation
    {
        public Guid Id { get; set; }
        public string? Content {  get; set; }
    }
}
