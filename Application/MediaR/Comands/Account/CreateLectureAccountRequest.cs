using Application.MediaR.Pipeline;
using Domain.Types.ErrorTypes.Unions.Account;
using Domain.Untils;
using MediatR;

namespace Application.MediaR.Comands.Account;

public class CreateLectureAccountRequest:IRequest<MutationPayload<CreateLectureAccountRequest,CreateAccountError>>,IRequireValidation
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}