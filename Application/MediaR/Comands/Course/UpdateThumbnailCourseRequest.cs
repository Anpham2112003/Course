using Application.MediaR.Pipeline;
using Domain.Types.ErrorTypes.Unions.Course;
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
    public class UpdateThumbnailCourseRequest:IRequest<MutationPayload<string,UpdateThumbnailCourseError>>,IRequireValidation
    {
        public Guid Id { get; set; }

        [GraphQLType(typeof(UploadType))]
        public IFile? File { get; set; }
    }
}
