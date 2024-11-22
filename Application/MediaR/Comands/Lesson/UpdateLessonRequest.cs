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
    public class UpdateLessonRequest:IRequest<MutationPayload<UpdateLessonRequest,UpdateLessonError>>
    {
        public Guid Id { get; set; }
        public string? Title {  get; set; }
        public string? Url {  get; set; }
        public float? Duration { get; set; }
    }
}
