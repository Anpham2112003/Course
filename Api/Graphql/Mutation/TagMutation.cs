using Application.MediaR.Comands.Tag;
using Domain.Types.ErrorTypes.Unions.Tag;
using Domain.Untils;
using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using MediatR;

namespace Api.Schemas.Mutation
{
    [ExtendObjectType(typeof(Mutations))]
    public class TagMutation
    {
        [Authorize(Roles = new[] {"Admin"})]
        public async Task<MutationPayload<CreateTagRequest,CreateTagError>> createTag([Service] IMediator mediator, CreateTagRequest input,CancellationToken cancellationToken)
        {
            var result = await mediator.Send(input, cancellationToken);

            return result;
        }

        [Authorize(Roles = new[] { "Admin" })]
        public async Task<MutationPayload<UpdateTagRequest, UpdateTagError>> updateTag([Service] IMediator mediator, UpdateTagRequest input, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(input, cancellationToken);

            return result;
        }

        [Authorize(Roles = new[] { "Admin" })]
        public async Task<MutationPayload<DeleteTagRequest, DeleteTagError>> deleteTag([Service] IMediator mediator, DeleteTagRequest input, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(input, cancellationToken);

            return result;
        }
    }
}
