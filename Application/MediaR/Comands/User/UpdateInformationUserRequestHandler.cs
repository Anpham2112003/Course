using AutoMapper;
using Domain.Interfaces.UnitOfWork;
using Domain.Types.ErrorTypes.BaseError.UserUnion;
using Domain.Types.ErrorTypes.ErrorImplement.UserErors;
using Domain.Untils;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.User
{
    public class UpdateInformationUserRequestHandler : IRequestHandler<UpdateInformationUserRequest, MutationPayload<UpdateInformationUserRequest, UpdateInformationUserError>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IHttpContextAccessor _httpContext;

        public UpdateInformationUserRequestHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContext)
        {
            _unitOfWork = unitOfWork;

            _httpContext = httpContext;
        }

        public async Task<MutationPayload<UpdateInformationUserRequest, UpdateInformationUserError>> Handle(UpdateInformationUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var errors = new List<UpdateInformationUserError>();


                var user = await _unitOfWork.userRepository.FindUserByAccountIdAsync(_httpContext.GetId());

                if (user is null || user.IsDeleted)
                {
                    errors.Add(new UserNotFoundError());

                    return new MutationPayload<UpdateInformationUserRequest, UpdateInformationUserError>
                    {
                        errors = errors
                    };
                }

                if (user.Id.Equals(request.Id) is false)
                {
                    errors.Add(new UserNotPermissionError());

                    return new MutationPayload<UpdateInformationUserRequest, UpdateInformationUserError>
                    {
                        errors = errors
                    };
                }

                user.Information = request.Information;

                _unitOfWork.userRepository.UpdateOne(user);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<UpdateInformationUserRequest, UpdateInformationUserError>
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
