using Domain.Interfaces.UnitOfWork;
using Domain.Interfaces.Upload;
using Domain.Types.ErrorTypes.BaseError.UserUnion;
using Domain.Types.ErrorTypes.ErrorImplement.UserErors;
using Domain.Untils;
using HotChocolate.Types;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.User
{
    public class UploadAvatarUserRequestHandler : IRequestHandler<UploadAvatarUserRequest, MutationPayload<string, UploadAvatarUserError>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICloudinaryUploadService _uploadService;

        private readonly IHttpContextAccessor _contextAccessor;

        public UploadAvatarUserRequestHandler(IUnitOfWork unitOfWork, ICloudinaryUploadService uploadService, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _uploadService = uploadService;
            _contextAccessor = contextAccessor;
        }

        public async Task<MutationPayload<string, UploadAvatarUserError>> Handle(UploadAvatarUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var errors = new List<UploadAvatarUserError>();

                var accountId = _contextAccessor.GetId();

                if (accountId.Equals(Guid.Empty) || accountId.Equals(request.Id) is false)
                {
                    errors.Add(new UserNotPermissionError());

                    return new MutationPayload<string, UploadAvatarUserError>
                    {
                        errors = errors,
                    };
                }

                var user = await _unitOfWork.userRepository.FindUserByAccountIdAsync(accountId);

                if (user is null || user.IsDeleted)
                {
                    errors.Add(new UserNotFoundError());

                    return new MutationPayload<string, UploadAvatarUserError>
                    {
                        errors = errors,
                    };
                }

                var upload = await _uploadService.UploadImageAsync(request.File!, cancellationToken);

               

                 

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
