using Application.Account;
using ApplicationCore.Errors;
using ApplicationCore.Untils;
using Domain.DTOs;
using Domain.Entities;
using HotChocolate;
using HotChocolate.Language;
using HotChocolate.Types;
using Infrastructure.Services.UnitOfWorkService;
using MediatR;

namespace Api.Mutation
{
    [ExtendObjectType(typeof(Mutations))]
    public class AccountMutation
    {
        public async Task<CreateAccountRequest> createAccount([Service] IMediator mediator, CreateAccountRequest input, CancellationToken cancellation)
        {
            var result = await mediator.Send(input, cancellation);

            return result;

        }

        public async Task<LoginResponse> loginAccount([Service] IMediator mediator, LoginAccountRequest input, CancellationToken cancellation)
        {
            {
                var result = await mediator.Send(input, cancellation);

                return result;
            }

        }
    }
}
