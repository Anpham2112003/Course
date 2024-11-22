using Domain.Types.ErrorTypes.Unions.Topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Topic
{
    public class TopicCourseExistError : AddTopicToCourseError
    {
        public string? code { get; set; }=nameof(TopicCourseExistError);
        public string? message { get; set; } = "Topic added to Course!";
    }
}
