using Domain.Types.ErrorTypes.Unions.Topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Topic
{
    public class TopicNotFoundError : UpdateTopicError,DeleteTopicError
    {
        public string? code { get; set; } = nameof(TopicNotFoundError);
        public string? message { get; set; } = "Topic not found!";
    }
}
