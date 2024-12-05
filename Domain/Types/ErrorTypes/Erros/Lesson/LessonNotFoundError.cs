using Domain.Types.ErrorTypes.Unions.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Types.ErrorTypes.Unions.Report;

namespace Domain.Types.ErrorTypes.Erros.Lesson
{
    public class LessonNotFoundError : UpdateLessonError,DeleteLessonError,CreateReportError
    {
        public string? code { get; set; }=nameof(LessonNotFoundError);
        public string? message { get; set; } = "Not found lesson!";
    }
}
