using Domain.Types.ErrorTypes.Unions.Cart;
using Domain.Types.ErrorTypes.Unions.CategoryLesson;
using Domain.Types.ErrorTypes.Unions.Course;
using Domain.Types.ErrorTypes.Unions.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Course
{
    public class CourseNotFoundError : UpdateCourseError, UpdateThumbnailCourseError
        , DeleteCourseError, CreateCategoryLessonError,CreateCartError,PublishCourseError,PaymentError
    {
        public string? code { get; set; } = nameof(CourseNotFoundError);
        public string? message { get; set; } = "No courses found!";
    }
}
