using Domain.Types.ErrorTypes.Unions.Permission;
using Domain.Types.ErrorTypes.Unions.Role;

namespace Domain.Types.ErrorTypes.Erros.Permission;

public class PermissionNotFoundError:UpdatePermissionError,DeletePermissionError,AddPermissionToRoleError,DeleteRolePermissionError
{
    public string? code { get; set; } = nameof(PermissionNotFoundError);
    public string? message { get; set; }="Permission not found";
}