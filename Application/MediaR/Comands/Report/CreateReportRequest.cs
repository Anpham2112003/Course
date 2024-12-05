using Domain.Types.ErrorTypes.Unions.Report;
using Domain.Untils;
using MediatR;

namespace Application.MediaR.Comands.Report;

public class CreateReportRequest:IRequest<MutationPayload<CreateReportRequest,CreateReportError>>
{
    public Guid Id { get; set; }
    public Guid LessonId { get; set; }
    public string? Content { get; set; }
}