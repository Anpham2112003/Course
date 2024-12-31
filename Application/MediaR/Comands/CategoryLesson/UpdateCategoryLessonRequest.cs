using Application.MediaR.Pipeline;
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
    public class UpdateCategoryLessonRequest:IRequest<MutationPayload<UpdateCategoryLessonRequest,UpdateCategoryLessonError>>,IRequireValidation
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
