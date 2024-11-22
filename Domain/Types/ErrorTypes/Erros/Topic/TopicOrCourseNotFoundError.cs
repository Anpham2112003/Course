using Domain.Types.ErrorTypes.Unions.Topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Topic
{
    public class TopicOrCourseNotFoundError : AddTopicToCourseError
    {
        public string? code { get; set; }=nameof(TopicOrCourseNotFoundError);
        public string? message { get; set; } = "Not found topic or course!";
    }
}
