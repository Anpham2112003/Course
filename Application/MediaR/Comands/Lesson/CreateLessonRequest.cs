using Domain.Types.ErrorTypes.Unions.Lesson;
using Domain.Untils;
using HotChocolate.Types;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Lesson
{
    public class CreateLessonRequest:IRequest<MutationPayload<CreateLessonRequest,CreateLessonError>>
    {
        public Guid Id { get; set; }
        public Guid CategoryLessonId { get; set; }
        public Guid UserId { get; set; }
        public string? Title {  get; set; }
        public float Duration {  get; set; }
        public string? Url {  get; set; }
    }
}
