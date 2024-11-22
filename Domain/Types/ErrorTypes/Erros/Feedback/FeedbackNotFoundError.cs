using Domain.Types.ErrorTypes.Unions.Feedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Feedback
{
    public class FeedbackNotFoundError : UpdateFeedbackError,DeleteFeedbackError
    {
        public string? code { get; set; }=nameof(FeedbackNotFoundError);
        public string? message { get; set; } = "Feedback not found!";
    }
}
