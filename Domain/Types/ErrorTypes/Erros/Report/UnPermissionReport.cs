using Domain.Types.ErrorTypes.Unions.Report;

namespace Domain.Types.ErrorTypes.Erros.Report;

public class UnPermissionReport:CreateReportError
{
    public string? code { get; set; }=nameof(UnPermissionReport);   
    public string? message { get; set; }="You have not permission!";
}