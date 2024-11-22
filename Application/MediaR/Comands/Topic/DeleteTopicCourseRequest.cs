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
    public class DeleteTopicCourseRequest:IRequest<MutationPayload<DeleteTopicCourseRequest,DeleteTopicCourseError>>
    {
        public int TopicId {  get; set; }
        public Guid CourseId { get; set; }
    }
}
