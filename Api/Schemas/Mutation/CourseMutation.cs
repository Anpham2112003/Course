using Application.MediaR.Comands.Course;
using Domain.Entities;
using Domain.Types.ErrorTypes.BaseError.CourseUnion;
using Domain.Untils;
using HotChocolate;
using HotChocolate.Types;
using MediatR;
using System.Threading;

namespace Api.Schemas.Mutation
{
    [ExtendObjectType(typeof(Mutations))]
    public class CourseMutation
    {
        public async Task<MutationPayload<CourseEntity,CreateCourseError>> createCourse([Service] IMediator mediator, CreateCourseRequest input,CancellationToken CancellationToken)
        {
            var result = await mediator.Send(input, CancellationToken);

            return result;
        }

        public async Task<MutationPayload<CourseEntity, UpdateCourseError>> updateCourse([Service] IMediator mediator, UpdateCourseRequest input, CancellationToken CancellationToken)
        {
            var result = await mediator.Send(input, CancellationToken);

            return result;
        }

        public async Task<MutationPayload<string, UpdateThumbnailCourseError>> updateThumbnailCourse([Service] IMediator mediator, UpdateThumbnailCourseRequest input, CancellationToken CancellationToken)
        {
            var result = await mediator.Send(input, CancellationToken);

            return result;
        }



    }
}
