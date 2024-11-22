using Domain.Types.ErrorTypes.Unions.Topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Topic
{
    public class TopicCourseNotFoundError : DeleteTopicCourseError
    {
        public string? code { get; set; }=nameof(TopicCourseNotFoundError);
        public string? message { get; set; } = "TopicCourse not found";
    }
}
