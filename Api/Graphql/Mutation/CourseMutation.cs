using System.Net;
using Application.MediaR.Comands.Course;
using Domain.Entities;
using Domain.Types.ErrorTypes.Unions.Course;
using Domain.Untils;
using HotChocolate;
using HotChocolate.Types;
using MediatR;
using System.Threading;
using HotChocolate.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Api.Middleware;

namespace Api.Schemas.Mutation
{
    [ExtendObjectType(typeof(Mutations))]
    public class CourseMutation
    {
        [RequirePerrmission]
        public async Task<MutationPayload<CourseEntity,CreateCourseError>> createCourse([Service] IMediator mediator, CreateCourseRequest input,CancellationToken CancellationToken)
        {
            var result = await mediator.Send(input, CancellationToken);

            return result;
        }

        [Authorize(Roles = new[] { "Lecture" })]

        public async Task<MutationPayload<UpdateCourseRequest, UpdateCourseError>> updateCourse([Service] IMediator mediator, UpdateCourseRequest input, CancellationToken CancellationToken)
        {
            var result = await mediator.Send(input, CancellationToken);

            return result;
        }

        [Authorize(Roles = new[] { "Lecture" })]

        public async Task<MutationPayload<string, UpdateThumbnailCourseError>> updateThumbnailCourse([Service] IMediator mediator, UpdateThumbnailCourseRequest input, CancellationToken CancellationToken)
        {
            var result = await mediator.Send(input, CancellationToken);

            return result;
        }

        [Authorize(Roles = new[] { "Lecture" })]
        public async Task<MutationPayload<Guid, PublishCourseError>> publishCourse([Service] IMediator mediator, PublishCourseRequest input, CancellationToken CancellationToken)
        {
            var result = await mediator.Send(input, CancellationToken);

            return result;
        }

        [Authorize(Roles = new[] { "Admin","Lecture" })]
        public async Task<MutationPayload<Guid, DeleteCourseError>> deleteCourse([Service] IMediator mediator, DeleteCourseRequest input, CancellationToken CancellationToken)
        {
            var result = await mediator.Send(input, CancellationToken);

            return result;
        }



    }
}
