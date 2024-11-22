using Domain.Types.ErrorTypes.Unions.Feedback;
using Domain.Untils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.FeedBack
{
    public class UpdateFeedbackRequest:IRequest<MutationPayload<UpdateFeedbackRequest,UpdateFeedbackError>>
    {
        public Guid Id { get; set; }
        public string? Content {  get; set; }
    }
}
