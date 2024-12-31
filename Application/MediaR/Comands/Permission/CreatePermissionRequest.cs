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
    public class CreatePermissionRequest:IRequest<MutationPayload<CreatePermissionRequest,CreatePermissionError>>,IRequireValidation
    {
        public string? Route {  get; set; }
        public bool State {  get; set; }
    }
}
