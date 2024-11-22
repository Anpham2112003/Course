using Domain.Types.ErrorTypes.Unions.Lesson;
using Domain.Untils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Lesson
{
    public class DeleteLessonRequest:IRequest<MutationPayload<Guid,DeleteLessonError>>
    {
        public Guid Id { get; set; }
    }
}
