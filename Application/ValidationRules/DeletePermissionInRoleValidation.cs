using Application.MediaR.Comands.Permission;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class DeletePermissionInRoleValidation : AbstractValidator<DeleteRolePermissionRequest>
    {
        public DeletePermissionInRoleValidation()
        {
            RuleFor(x=>x.PermissionId).NotNull().NotEmpty();
            RuleFor(x=>x.RoleId).NotEmpty().NotEmpty();
        }
    }
}
