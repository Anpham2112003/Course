using Domain.Types.ErrorTypes.Unions.CategoryLesson;
using Domain.Untils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.CategoryLesson
{
    public class CreateCategoryLessonRequest:IRequest<MutationPayload<CreateCategoryLessonRequest,CreateCategoryLessonError>>
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string? Name { get; set; }
    }
}
