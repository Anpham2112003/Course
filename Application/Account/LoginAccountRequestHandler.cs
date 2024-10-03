using ApplicationCore.Errors;
using ApplicationCore.Untils;
using Domain.DTOs;
using Domain.Entities;
using Domain.Options;
using Domain.Untils;
using HotChocolate;
using Infrastructure.Services.UnitOfWorkService;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Account
{
    public class LoginAccountRequestHandler : IRequestHandler<LoginAccountRequest, LoginResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOptionsMonitor<JwtOption> _options;
        public LoginAccountRequestHandler(IUnitOfWork unitOfWork, IOptionsMonitor<JwtOption> options)
        {
            _unitOfWork = unitOfWork;
            _options = options;
        }

        public async Task<LoginResponse> Handle(LoginAccountRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var account = await _unitOfWork.accountRepository.EntityQueryable()
                    .Where(x => x.Email == request.Email)
                    .Include(x => x.roleEntity)
                    .ThenInclude(x => x.permissionEntities)
                    .Select(x=> new AccountEntity
                    {
                        Id = x.Id,
                        Email = x.Email,
                        HashPassword = x.HashPassword,
                        IsDeleted = x.IsDeleted,
                        roleEntity=x.roleEntity
                    })
                    .FirstOrDefaultAsync(cancellationToken);

                if (account is null || Hash.VerifyHash(account.HashPassword!, request.Password!) is false)
                {
                    throw new GraphQLException(AccountErrors.AccountOrPassowrdError());
                }

                

               
            }
            catch (Exception )
            {

                throw ;
            }
        }
    }
}
