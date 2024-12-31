using Application.MediaR.Comands.Permission;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class CreatePermissionValidation : AbstractValidator<CreatePermissionRequest>
    {
        public CreatePermissionValidation()
        {
            RuleFor(x=>x.Route).NotNull().NotEmpty();
        }
    }
}
