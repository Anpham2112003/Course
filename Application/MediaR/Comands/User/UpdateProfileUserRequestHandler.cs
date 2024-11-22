using AutoMapper;
using Domain.Types.ErrorTypes.Erros.User;
using Domain.Types.ErrorTypes.Unions.User;
using Domain.Untils;
using Infrastructure.Unit0fWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.User
{
    public class UpdateProfileUserRequestHandler : IRequestHandler<UpdateProfileUserRequest, MutationPayload<UpdateProfileUserRequest, UpdateProfileUserError>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public UpdateProfileUserRequestHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<MutationPayload<UpdateProfileUserRequest, UpdateProfileUserError>> Handle(UpdateProfileUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var errors = new List<UpdateProfileUserError>();

                var accountId = _contextAccessor.GetId();

                var user = await _unitOfWork.userRepository.FindOneAsync(request.Id);

                if (user is null || user.IsDeleted)
                {
                    errors.Add(new UserNotFoundError());

                    return new MutationPayload<UpdateProfileUserRequest, UpdateProfileUserError>
                    {
                        errors = errors
                    };
                }

                if (accountId.Equals(user.AccountId) is false)
                {
                    errors.Add(new UserNotPermissionError());

                    return new MutationPayload<UpdateProfileUserRequest, UpdateProfileUserError>
                    {
                        errors = errors
                    };
                }

                _mapper.Map(request, user);

                _unitOfWork.userRepository.UpdateOne(user);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<UpdateProfileUserRequest, UpdateProfileUserError>
                {
                    payload = request,
                };

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
