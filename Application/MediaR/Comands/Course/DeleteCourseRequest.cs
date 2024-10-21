using Domain.Types.ErrorTypes.BaseError.CourseUnion;
using Domain.Untils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Course
{
    public class DeleteCourseRequest:IRequest<MutationPayload<Guid,DeleteCourseError>>
    {
        public Guid Id { get; set; }

    }
}
