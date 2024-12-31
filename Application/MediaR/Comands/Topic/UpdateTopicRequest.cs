using Application.MediaR.Pipeline;
using Domain.Types.ErrorTypes.Unions.Topic;
using Domain.Untils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Topic
{
    public class UpdateTopicRequest:IRequest<MutationPayload<UpdateTopicRequest,UpdateTopicError>>,IRequireValidation
    {
        public int  Id { get; set; }
        public string? Name {  get; set; }
    }
}
