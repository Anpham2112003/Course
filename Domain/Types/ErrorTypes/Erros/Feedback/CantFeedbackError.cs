using Domain.Types.ErrorTypes.Unions.Feedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Feedback
{
    public class CantFeedbackError : CreateFeedbackError
    {
        public string? code { get; set; }=nameof(CantFeedbackError);
        public string? message { get; set; } = "You have not purchased the course yet!";
    }
}
