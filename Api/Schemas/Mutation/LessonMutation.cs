using Application.MediaR.Comands.Lesson;
using Domain.Types.ErrorTypes.Unions.Lesson;
using Domain.Untils;
using HotChocolate;
using HotChocolate.Types;
using MediatR;

namespace Api.Schemas.Mutation
{
    [ExtendObjectType(typeof(Mutations))]
    public class LessonMutation
    {
        public async Task<MutationPayload<CreateLessonRequest,CreateLessonError>> createLesson([Service]IMediator mediator,CreateLessonRequest input,CancellationToken cancellation)
        {
            var result = await mediator.Send(input,cancellation);

            return result;
        }

        public async Task<MutationPayload<UpdateLessonRequest, UpdateLessonError>> updateLesson([Service]IMediator mediator, UpdateLessonRequest input, CancellationToken cancellation)
        {
            var result = await mediator.Send(input, cancellation);

            return result;
        }

        public async Task<MutationPayload<Guid, DeleteLessonError>> deleteLesson([Service]IMediator mediator, DeleteLessonRequest input, CancellationToken cancellation)
        {
            var result = await mediator.Send(input, cancellation);

            return result;
        }


    }
}
