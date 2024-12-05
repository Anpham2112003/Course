using Domain.Types.ErrorTypes.Unions.CategoryLesson;
using Domain.Types.ErrorTypes.Unions.Course;
using Domain.Types.ErrorTypes.Unions.Lesson;
using Domain.Types.ErrorTypes.Unions.Message;
using Domain.Types.ErrorTypes.Unions.Topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Course
{
    public class UnAuthorError : CreateCourseError, UpdateCourseError, UpdateThumbnailCourseError,
        DeleteCourseError, CreateCategoryLessonError, UpdateCategoryLessonError, 
        DeleteCategoryLessonError,CreateLessonError,UpdateLessonError,
        DeleteLessonError,PublishCourseError,AddTopicToCourseError,DeleteTopicCourseError
    {
        public string? code { get; set; } = nameof(UnAuthorError);
        public string? message { get; set; } = "You are not the author!";
    }
}
