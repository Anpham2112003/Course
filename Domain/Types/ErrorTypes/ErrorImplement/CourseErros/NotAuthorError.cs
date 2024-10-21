using Domain.Types.ErrorTypes.BaseError.CourseUnion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.ErrorImplement.CourseErros
{
    public class NotAuthorError : CreateCourseError,UpdateCourseError,UpdateThumbnailCourseError,DeleteCourseError
    {
        public string? code { get; set; }=nameof(NotAuthorError);
        public string? message { get; set; } = "You are not the author!";
    }
}
