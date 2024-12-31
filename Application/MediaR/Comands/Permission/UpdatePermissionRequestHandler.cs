using Domain.Types.ErrorTypes.Erros.Permission;
using Domain.Types.ErrorTypes.Unions.Permission;
using Domain.Untils;
using Infrastructure.Unit0fWork;
using MediatR;

namespace Application.MediaR.Comands.Permission;

public class UpdatePermissionRequestHandler:IRequestHandler<UpdatePermissionRequest,MutationPayload<UpdatePermissionRequest,UpdatePermissionError>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePermissionRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<MutationPayload<UpdatePermissionRequest, UpdatePermissionError>> Handle(UpdatePermissionRequest request, CancellationToken cancellationToken)
    {
        var errors = new List<UpdatePermissionError>();

        try
        {
            var permission = await _unitOfWork.permissionRepository.FindOneAsync(request.Id);

            if (permission == null)
            {
                errors.Add(new PermissionNotFoundError());

                return new MutationPayload<UpdatePermissionRequest, UpdatePermissionError>()
                {
                    errors = errors
                };
            }
            
            permission.Route=request.Route;
            permission.State = request.State;
            
            _unitOfWork.permissionRepository.UpdateOne(permission);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new MutationPayload<UpdatePermissionRequest, UpdatePermissionError>()
            {
                payload = request
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}