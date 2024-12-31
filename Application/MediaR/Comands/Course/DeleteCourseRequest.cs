using Application.MediaR.Pipeline;
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
    public class DeleteCourseRequest:IRequest<MutationPayload<Guid,DeleteCourseError>>,IRequireValidation
    {
        public Guid Id { get; set; }

    }
}
