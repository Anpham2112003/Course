using Api.Schemas.Mutation;
using Application.MediaR.Comands.Comment;
using Domain.Types.ErrorTypes.Unions.Comment;
using Domain.Untils;
using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using MediatR;

namespace Api.Graphql.Mutation
{
    [ExtendObjectType(typeof(Mutations))]
    public class CommentMutation
    {

        [Authorize]
        public async Task<MutationPayload<CreateCommentRequest,CreateCommentError>> addComment([Service] IMediator mediator,CreateCommentRequest input,CancellationToken cancellation)
        {
            return await mediator.Send(input, cancellation);
        }

        [Authorize]
        public async Task<MutationPayload<UpdateCommentRequest, UpdateCommentError>> updateComment([Service] IMediator mediator, UpdateCommentRequest input, CancellationToken cancellation)
        {
            return await mediator.Send(input, cancellation);
        }


        [Authorize]
        public async Task<MutationPayload<DeleteCommentRequest, DeleteCommentError>> deleteComment([Service] IMediator mediator, DeleteCommentRequest input, CancellationToken cancellation)
        {
            return await mediator.Send(input, cancellation);
        }
    }
}
