using Application.MediaR.Comands.FeedBack;
using Application.MediaR.Comands.Topic;
using Domain.Types.ErrorTypes.Unions.Feedback;
using Domain.Types.ErrorTypes.Unions.Topic;
using Domain.Untils;
using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using MediatR;

namespace Api.Schemas.Mutation
{
    [ExtendObjectType(typeof(Mutations))]
    public class FeedbackMutation
    {
        [Authorize]
        public async Task<MutationPayload<CreateFeedbackRequest, CreateFeedbackError>> createFeedback([Service] IMediator mediator, CreateFeedbackRequest input, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(input, cancellationToken);

            return result;
        }

        [Authorize]

        public async Task<MutationPayload<UpdateFeedbackRequest, UpdateFeedbackError>> updateFeedback([Service] IMediator mediator, UpdateFeedbackRequest input, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(input, cancellationToken);

            return result;
        }

        [Authorize]
        public async Task<MutationPayload<DeleteFeedbackRequest, DeleteFeedbackError>> deleteFeedback([Service] IMediator mediator, DeleteFeedbackRequest input, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(input, cancellationToken);

            return result;
        }
    }
}
