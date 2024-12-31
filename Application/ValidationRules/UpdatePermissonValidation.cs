using Application.MediaR.Comands.Permission;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ValidationRules
{
    public class UpdatePermissonValidation : AbstractValidator<UpdatePermissionRequest>
    {
        public UpdatePermissonValidation()
        {
            RuleFor(x=>x.Id).NotNull().NotEmpty();
            RuleFor(x=>x.Route).NotNull().NotEmpty();
        }
    }
}
