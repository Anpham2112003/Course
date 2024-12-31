using Domain.Types.ErrorTypes.Unions.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Permission
{
    public class RouteDuplicateError : CreatePermissionError
    {
        public string? code { get; set; }=nameof(RouteDuplicateError);
        public string? message { get; set; } = "Route duplicate!";
    }
}
