using Domain.Entities;
using Domain.Types.ErrorTypes.Erros.Permission;
using Domain.Types.ErrorTypes.Erros.Role;
using Domain.Types.ErrorTypes.Unions.Permission;
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
    public class AddPermissionToRoleRequestHandler : IRequestHandler<AddPermissionToRoleRequest, MutationPayload<AddPermissionToRoleRequest, AddPermissionToRoleError>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddPermissionToRoleRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MutationPayload<AddPermissionToRoleRequest, AddPermissionToRoleError>> Handle(AddPermissionToRoleRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<AddPermissionToRoleError>();

            try
            {
                var checkRole = await _unitOfWork.roleRepository.FindOneAsync(request.RoleId);

                var checkPermission = await _unitOfWork.permissionRepository.FindOneAsync(request.PermissionId);

                if (checkRole == null)
                {
                    errors.Add(new RoleNotFoundError());

                    return new MutationPayload<AddPermissionToRoleRequest, AddPermissionToRoleError>
                    {
                        errors = errors
                    };
                }

                if (checkPermission == null)
                {
                    errors.Add(new PermissionNotFoundError());

                    return new MutationPayload<AddPermissionToRoleRequest, AddPermissionToRoleError>
                    {
                        errors = errors
                    };
                }

                var rolePermission = new RolePermission
                {
                    RoleId = request.RoleId,
                    PermissionId = request.PermissionId,
                };

                await _unitOfWork.permissionRepository.AddRolePermission(rolePermission, cancellationToken);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<AddPermissionToRoleRequest, AddPermissionToRoleError>
                {
                    payload = request
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
