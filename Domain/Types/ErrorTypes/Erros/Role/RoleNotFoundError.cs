using Domain.Types.ErrorTypes.Unions.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Role
{
    public class RoleNotFoundError :AddPermissionToRoleError,DeletePermissionError
    {
        public string? code { get; set; }=nameof(RoleNotFoundError);
        public string? message { get; set; } = "Role not found!";
    }
}
