using System.Security.Claims;
using Domain.DTOs;
using Domain.Entities;
using Domain.Options;
using Domain.Types.EnumTypes;
using Domain.Untils;
using Infrastructure.Unit0fWork;
using MediatR;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Application.MediaR.Comands.Account;

public class GoogleLoginRequestHandler: IRequestHandler<GoogleLoginRequest,LoginResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOptionsMonitor<JwtOption> _options;

    public GoogleLoginRequestHandler(IUnitOfWork unitOfWork, IOptionsMonitor<JwtOption> options)
    {
        _unitOfWork = unitOfWork;
        _options = options;
    }

    public async Task<LoginResponse> Handle(GoogleLoginRequest request, CancellationToken cancellationToken)
    {
        var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var email = $"Google:{request.Email}";

            var account = await _unitOfWork.accountRepository.FindAccountAndRoleAsync(x => x.Email == email,cancellationToken);

            if (account is null)
            {
                var createAccount = new AccountEntity
                {
                    Id = Guid.NewGuid(),
                    Email = email,
                    LoginType = EnumLogin.Google,
                    RoleId = 1
                    
                };

                var createUser = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    AccountId = createAccount.Id,
                    FullName = request.Name
                };

                var role = await _unitOfWork.roleRepository.GetRoleAndPermissionByIdAsync(1);

                if (role is null)
                {
                    throw new Exception("Role doesn't exist");
                }
                
                await _unitOfWork.accountRepository.AddOneAsync(createAccount,cancellationToken);
                
                await _unitOfWork.userRepository.AddOneAsync(createUser,cancellationToken);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                
                await transaction.CommitAsync(cancellationToken);
                
               
             
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Email, request.Email!),
                    new Claim(ClaimTypes.PrimarySid, createUser.Id.ToString()),
                    new Claim(ClaimTypes.Name, request.Name!),
                    new Claim(ClaimTypes.NameIdentifier, createUser.Id.ToString()),
                };

                var accesstoken = Jwt.GenerateAccessToken(_options, claims);
                
                var refreshtoken = Jwt.GenerateRefreshToken(_options, claims);

                return new LoginResponse
                {
                    Id = createUser.Id,
                    Accesstoken = accesstoken,
                    Refreshtoken = refreshtoken,
                };


            }
            else
            {
               

                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Email, request.Email!),
                    new Claim(ClaimTypes.PrimarySid, account.userEntity!.Id.ToString()),
                    new Claim(ClaimTypes.Name, request.Name!),
                    new Claim(ClaimTypes.NameIdentifier, account.userEntity!.Id.ToString()),
                };

                var accesstoken = Jwt.GenerateAccessToken(_options, claims);
                
                var refreshtoken = Jwt.GenerateRefreshToken(_options, claims);
                
                return new LoginResponse
                {
                    Id = account.userEntity.Id,
                    Accesstoken = accesstoken,
                    Refreshtoken = refreshtoken,
                };
            }
            
            
            
            
        }
        catch (Exception e)
        {
           await transaction.RollbackAsync();
            
            Console.WriteLine(e);
            throw;
        }
        
    }
}