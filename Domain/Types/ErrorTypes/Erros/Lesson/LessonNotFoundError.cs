using Domain.Types.ErrorTypes.Unions.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Lesson
{
    public class LessonNotFoundError : UpdateLessonError,DeleteLessonError
    {
        public string? code { get; set; }=nameof(LessonNotFoundError);
        public string? message { get; set; } = "Not found lesson!";
    }
}
