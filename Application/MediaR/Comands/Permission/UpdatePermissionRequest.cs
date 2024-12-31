using Application.MediaR.Pipeline;
using Domain.Types.ErrorTypes.Unions.Permission;
using Domain.Untils;
using MediatR;

namespace Application.MediaR.Comands.Permission;

public class UpdatePermissionRequest:IRequest<MutationPayload<UpdatePermissionRequest,UpdatePermissionError>>,IRequireValidation
{
    public int Id { get; set; }
    public string? Route{get;set;}
    public bool State { get; set; }
}