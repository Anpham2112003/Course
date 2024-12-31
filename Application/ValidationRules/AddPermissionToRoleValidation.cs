using Application.MediaR.Comands.Permission;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class AddPermissionToRoleValidation : AbstractValidator<AddPermissionToRoleRequest>
    {
        public AddPermissionToRoleValidation()
        {
            RuleFor(x=>x.RoleId).NotNull().NotEmpty();
            RuleFor(x=>x.PermissionId).NotNull().NotEmpty();
        }
    }
}
