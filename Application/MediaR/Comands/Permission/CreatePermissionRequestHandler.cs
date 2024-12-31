using Domain.Entities;
using Domain.Types.ErrorTypes.Erros.Permission;
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
    public class CreatePermissionRequestHandler : IRequestHandler<CreatePermissionRequest, MutationPayload<CreatePermissionRequest, CreatePermissionError>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePermissionRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MutationPayload<CreatePermissionRequest, CreatePermissionError>> Handle(CreatePermissionRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<CreatePermissionError>();

            try
            {
                var check = await _unitOfWork.permissionRepository.CheckDuplicateRoute(request.Route!,cancellationToken);

                if (check)
                {
                    errors.Add(new RouteDuplicateError());

                    return new MutationPayload<CreatePermissionRequest, CreatePermissionError>
                    {
                        errors = errors
                    };
                }

                var permisssion = new PermissionEntity
                {
                    Route = request.Route,
                    State = request.State,
                };

                _unitOfWork.permissionRepository.AddOne(permisssion);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<CreatePermissionRequest, CreatePermissionError>
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
