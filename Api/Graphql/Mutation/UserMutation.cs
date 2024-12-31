using Application.MediaR.Comands.User;
using Domain.Types.ErrorTypes.Unions.User;
using Domain.Untils;
using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using MediatR;

namespace Api.Schemas.Mutation
{
    [ExtendObjectType(typeof(Mutations))]
    
    public class UserMutation
    {
        [Authorize]
        public async Task<MutationPayload<UpdateProfileUserRequest,UpdateProfileUserError>> updateProfile([Service] IMediator mediator, UpdateProfileUserRequest input, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(input, cancellationToken);

            return result;
        }

        [Authorize]
        public async Task<MutationPayload<UpdateInformationUserRequest, UpdateInformationUserError>> updateInformation(
            [Service] IMediator mediator, UpdateInformationUserRequest input, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(input, cancellationToken);
            
            return result;
        }

        [Authorize()]
        public async Task<MutationPayload<string,UploadAvatarUserError>> uploadAvatar(
            [Service] IMediator mediator, UploadAvatarUserRequest input,CancellationToken cancellationToken)
        {
            var result = await mediator.Send(input, cancellationToken);

            return result;
        }

        [Authorize()]
        public async Task<MutationPayload<string,DeleteAvatarUserError>> deleteAvatar(
            [Service] IMediator mediator, DeleteAvatarUserRequest input, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(input, cancellationToken);

            return result;
        }
    }
}
