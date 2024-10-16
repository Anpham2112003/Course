using Application.MediaR.Comands.User;
using Domain.Types.ErrorTypes.BaseError.UserUnion;
using Domain.Untils;
using HotChocolate;
using HotChocolate.Types;
using MediatR;

namespace Api.Schemas.Mutation
{
    [ExtendObjectType(typeof(Mutations))]
    public class UserMutation
    {
        public async Task<MutationPayload<UpdateProfileUserRequest,UpdateProfileUserError>> updateProfile([Service] IMediator mediator, UpdateProfileUserRequest input, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(input, cancellationToken);

            return result;
        }


        public async Task<MutationPayload<UpdateInformationUserRequest, UpdateInformationUserError>> updateInformation(
            [Service] IMediator mediator, UpdateInformationUserRequest input, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(input, cancellationToken);
            
            return result;
        }
    }
}
