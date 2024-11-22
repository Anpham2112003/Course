using Domain.Types.ErrorTypes.Unions.Topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Topic
{
    public class TopicNameExistError : CreateTopicError,UpdateTopicError
    {
        public string? code { get; set; } = nameof(TopicNameExistError);
        public string? message { get; set; } = "Topic was existed!";
    }
}
