using Domain.Interfaces.UnitOfWork;
using Domain.Interfaces.Upload;
using Domain.Types.ErrorTypes.BaseError.AccountUnion;
using Domain.Types.ErrorTypes.BaseError.UserUnion;
using Domain.Types.ErrorTypes.ErrorImplement.UserErors;
using Domain.Untils;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.User
{
    public class DeleteAvatarUserRequestHandler : IRequestHandler<DeleteAvatarUserRequest, MutationPayload<string, DeleteAvatarUserError>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICloudinaryUploadService _cloudinary;

        private readonly IHttpContextAccessor _contextAccessor;

        public DeleteAvatarUserRequestHandler(IUnitOfWork unitOfWork, ICloudinaryUploadService cloudinary, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _cloudinary = cloudinary;
            _contextAccessor = contextAccessor;
        }

        public async Task<MutationPayload<string, DeleteAvatarUserError>> Handle(DeleteAvatarUserRequest request, CancellationToken cancellationToken)
        {
            var trans = await _unitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                var errors = new List<DeleteAvatarUserError>();

                var user = await _unitOfWork.userRepository.FindUserByAccountIdAsync(_contextAccessor.GetId());

                if(user is null || user.IsDeleted)
                {
                    errors.Add(new UserNotFoundError());

                    return new MutationPayload<string, DeleteAvatarUserError>
                    {
                        errors = errors,
                    };
                }

                if(user.AccountId.Equals(request.Id) is false)
                {
                    errors.Add(new UserNotPermissionError());

                    return new MutationPayload<string, DeleteAvatarUserError>
                    {
                        errors = errors
                    };
                }

                if (user.Avatar.IsNullOrEmpty())
                {
                    errors.Add(new AvatarHasDeleted());

                    return new MutationPayload<string, DeleteAvatarUserError>
                    {
                        errors = errors,
                    };
                }

                var imageId = user.Avatar!.Split('/').Last().Split('.').First();

                var task =_cloudinary.DeleteImageByPublicId(imageId);

                user.Avatar = "";

                _unitOfWork.userRepository.UpdateOne(user);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                await trans.CommitAsync(cancellationToken);

                return new MutationPayload<string, DeleteAvatarUserError>
                {
                    payload = imageId,
                };
            }
            catch (Exception)
            {
                await trans.RollbackAsync();

                throw;
            }
        }
    }
}
