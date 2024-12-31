using Application.MediaR.Pipeline;
using Domain.Types.ErrorTypes.Unions.Permission;
using Domain.Untils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Permission
{
    public class AddPermissionToRoleRequest : IRequest<MutationPayload<AddPermissionToRoleRequest, AddPermissionToRoleError>>,IRequireValidation
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
