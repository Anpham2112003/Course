using Application.MediaR.Pipeline;
using Domain.Types.ErrorTypes.Unions.Role;
using Domain.Untils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Permission
{
    public class DeleteRolePermissionRequest : IRequest<MutationPayload<DeleteRolePermissionRequest, DeleteRolePermissionError>>,IRequireValidation
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
