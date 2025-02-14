﻿using Application.MediaR.Comands.Account;
using Domain.DTOs;
using Domain.Entities;
using Domain.Types.ErrorTypes.Unions.Account;
using Domain.Untils;
using HotChocolate;
using HotChocolate.Language;
using HotChocolate.Types;
using MediatR;

namespace Api.Schemas.Mutation
{
    [ExtendObjectType(typeof(Mutations))]
    public class AccountMutation
    {
        public async Task<MutationPayload<CreateAccountRequest, CreateAccountError>> createAccount([Service] IMediator mediator, CreateAccountRequest input, CancellationToken cancellation)
        {
            var result = await mediator.Send(input, cancellation);

            return result;

        }

        public async Task<MutationPayload<CreateLectureAccountRequest,CreateAccountError>> createLectureAccount([Service] IMediator mediator, CreateLectureAccountRequest input,CancellationToken cancellation)
        {
            var result = await mediator.Send(input,cancellation);

            return result;
        }
        
        


        public async Task<MutationPayload<LoginResponse, LoginAccountError>> loginAccount([Service] IMediator mediator, LoginAccountRequest input, CancellationToken cancellation)
        {
            {
                var result = await mediator.Send(input, cancellation);

                return result;
            }

        }



        public async Task<MutationPayload<LoginResponse, RefreshTokenError>> refreshToken([Service] IMediator mediator, RefreshTokenRequest input, CancellationToken cancellation)
        {
            var result = await mediator.Send(input, cancellation);

            return result;
        }

        public async Task<MutationPayload<string, ForgetPassowordError>> forgetPassword([Service] IMediator mediator, ForgotPasswordRequest input, CancellationToken cancellation)
        {
            var result = await mediator.Send(input, cancellation);

            return result;
        }

        public async Task<MutationPayload<ResetPasswordRequest, ResetPasswordError>> resetPassowrd([Service] IMediator mediator, ResetPasswordRequest input, CancellationToken cancellation)
        {
            var result = await mediator.Send(input, cancellation);

            return result;
        }

        public async Task<MutationPayload<string, DeleteAccountError>> deleteAccount([Service] IMediator mediator, DeleteAccountRequest input, CancellationToken cancellation)
        {
            var result = await mediator.Send(input, cancellation);

            return result;
        }
    }
}
