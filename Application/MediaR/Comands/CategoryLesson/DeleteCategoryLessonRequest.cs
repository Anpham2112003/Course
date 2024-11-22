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
    public class DeleteCategoryLessonRequest:IRequest<MutationPayload<Guid,DeleteCategoryLessonError>>
    {
        public Guid Id { get; set; }
    }
}
