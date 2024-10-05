using Domain.DTOs;
using Infrastructure.Services.UnitOfWorkService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account
{
    public class RefreshTokenRequestHandler : IRequestHandler<RefreshTokenRequest, LoginResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RefreshTokenRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<LoginResponse> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
