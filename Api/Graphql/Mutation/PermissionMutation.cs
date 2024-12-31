using Api.Schemas.Mutation;
using Application.MediaR.Comands.Permission;
using Domain.Types.ErrorTypes.Unions.Permission;
using Domain.Untils;
using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using MediatR;

namespace Api.Graphql.Mutation;

[ExtendObjectType(typeof(Mutations))]
public class PermissionMutation
{
    [Authorize(Roles = new[] {"Admin"})]
    public async Task<MutationPayload<CreatePermissionRequest,CreatePermissionError>> createPermission([Service] IMediator mediator,CreatePermissionRequest input,CancellationToken cancellation)
    {
        return await mediator.Send(input, cancellation);
    }


    [Authorize(Roles = new[] {"Admin"})]
    public async Task<MutationPayload<UpdatePermissionRequest,UpdatePermissionError>> updatePermission([Service] IMediator mediator,UpdatePermissionRequest input,CancellationToken cancellation)
    {
        return await mediator.Send(input, cancellation);
    }

    [Authorize(Roles = new[] { "Admin" })]
    public async Task<MutationPayload<DeletePermissionRequest, DeletePermissionError>> deletePermission([Service] IMediator mediator,DeletePermissionRequest input,CancellationToken cancellation)
    {
        return await mediator.Send(input, cancellation);
    }

    [Authorize(Roles = new[] { "Admin" })]
    public async Task<MutationPayload<AddPermissionToRoleRequest,AddPermissionToRoleError>> addPermissionToRole([Service] IMediator mediator,AddPermissionToRoleRequest input,CancellationToken cancellation)
    {
        return await mediator.Send(input, cancellation);
    }
}