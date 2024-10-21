using Domain.Types.ErrorTypes.BaseError.CourseUnion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.ErrorImplement.CourseErros
{
    public class AuthorNotFoundError : CreateCourseError,UpdateCourseError,UpdateThumbnailCourseError,DeleteCourseError
    {
        public string? code { get; set; }=nameof(AuthorNotFoundError);
        public string? message { get; set; }="Author not found!";
    }
}
