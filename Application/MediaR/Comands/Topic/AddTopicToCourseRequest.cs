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
    public class AddTopicToCourseRequest : IRequest<MutationPayload<AddTopicToCourseRequest, AddTopicToCourseError>>,IRequireValidation
    {
        public int TopicId { get; set; }
        public Guid CourseId { get; set; }
    }
}
