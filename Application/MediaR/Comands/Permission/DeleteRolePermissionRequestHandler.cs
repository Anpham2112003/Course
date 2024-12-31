using Domain.Types.ErrorTypes.Unions.Role;
using Domain.Untils;
using Infrastructure.Unit0fWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Permission
{
    public class DeleteRolePermissionRequestHandler : IRequestHandler<DeleteRolePermissionRequest, MutationPayload<DeleteRolePermissionRequest, DeleteRolePermissionError>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRolePermissionRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<MutationPayload<DeleteRolePermissionRequest, DeleteRolePermissionError>> Handle(DeleteRolePermissionRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
