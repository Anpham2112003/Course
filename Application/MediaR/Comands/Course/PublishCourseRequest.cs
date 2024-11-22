using Domain.Types.ErrorTypes.Unions.Course;
using Domain.Untils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Course
{
    public class PublishCourseRequest:IRequest<MutationPayload<Guid,PublishCourseError>>
    {
        public Guid Id { get; set; }
    }
}
