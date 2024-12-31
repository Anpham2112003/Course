using Application.MediaR.Pipeline;
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
    public class CreateFeedbackRequest:IRequest<MutationPayload<CreateFeedbackRequest,CreateFeedbackError>>,IRequireValidation
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public int Rate {  get; set; }
        public string? Content {  get; set; }
    }
}
