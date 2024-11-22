using Application.MediaR.Comands.Tag;
using Application.MediaR.Comands.Topic;
using Domain.Types.ErrorTypes.Unions.Tag;
using Domain.Types.ErrorTypes.Unions.Topic;
using Domain.Untils;
using HotChocolate;
using HotChocolate.Types;
using MediatR;

namespace Api.Schemas.Mutation
{
    [ExtendObjectType(typeof(Mutations))]
    public class TopicMutation
    {
        public async Task<MutationPayload<CreateTopicRequest, CreateTopicError>> createTopic([Service] IMediator mediator, CreateTopicRequest input, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(input, cancellationToken);

            return result;
        }

        public async Task<MutationPayload<UpdateTopicRequest, UpdateTopicError>> updateTopic([Service] IMediator mediator, UpdateTopicRequest input, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(input, cancellationToken);

            return result;
        }

        public async Task<MutationPayload<DeleteTopicRequest, DeleteTopicError>> deleteTopic([Service] IMediator mediator, DeleteTopicRequest input, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(input, cancellationToken);

            return result;
        }

        public async Task<MutationPayload<AddTopicToCourseRequest,AddTopicToCourseError>> addTopicToCourse([Service] IMediator mediator,AddTopicToCourseRequest input,CancellationToken cancellation)
        {
            return await mediator.Send(input,cancellation);
        }

        public async Task<MutationPayload<DeleteTopicCourseRequest,DeleteTopicCourseError>> deleteTopicCourse([Service] IMediator mediator,DeleteTopicCourseRequest input,CancellationToken cancellation)
        {
            return await mediator.Send(input,cancellation);
        }

        
    }
}
