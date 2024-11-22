using Domain.Types.ErrorTypes.Unions.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Course
{
    public class PublishedError : PublishCourseError
    {
        public string? code { get; set; }=nameof(PublishedError);
        public string? message { get; set; } = "Course has published!";
    }
}
