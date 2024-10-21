using Domain.Types.ErrorTypes.BaseError.CourseUnion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.ErrorImplement.CourseErros
{
    public class CourseNotFoundError : UpdateCourseError,UpdateThumbnailCourseError,DeleteCourseError
    {
        public string? code { get; set; }=nameof(CourseNotFoundError);
        public string? message { get; set; } = "No courses found!";
    }
}
