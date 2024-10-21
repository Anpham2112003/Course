using Application.MediaR.Pipeline;
using Domain.Entities;
using Domain.Types.ErrorTypes.BaseError.AccountUnion;
using Domain.Types.ErrorTypes.BaseError.CourseUnion;
using Domain.Untils;
using HotChocolate;
using HotChocolate.Types;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Course
{
    public class CreateCourseRequest:IRequest<MutationPayload<CourseEntity,CreateCourseError>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public float Price { get; set; }     
        public string? Description { get; set; }

        [GraphQLType(typeof(UploadType))]
        public IFile? File { get; set; }

    }
}
