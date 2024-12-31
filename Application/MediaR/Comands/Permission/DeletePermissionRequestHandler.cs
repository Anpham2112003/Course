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
    public class DeletePermissionRequestHandler : IRequestHandler<DeletePermissionRequest, MutationPayload<DeletePermissionRequest, DeletePermissionError>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePermissionRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MutationPayload<DeletePermissionRequest, DeletePermissionError>> Handle(DeletePermissionRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<DeletePermissionError>();

            try
            {
                var permission = await _unitOfWork.permissionRepository.FindOneAsync(request.Id);

                if (permission is null)
                {
                    errors.Add(new PermissionNotFoundError());

                    return new MutationPayload<DeletePermissionRequest, DeletePermissionError>
                    {
                        errors = errors
                    };                                                                                                                                                                                                                                                                                                                                                                  
                }


                _unitOfWork.permissionRepository.DeleteOne(permission);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<DeletePermissionRequest, DeletePermissionError>
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
