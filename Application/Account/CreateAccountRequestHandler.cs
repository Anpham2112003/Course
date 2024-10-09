
using ApplicationCore.Untils;
using Domain.Entities;
using Domain.Errors;
using Domain.Errors.UnionError.AccountUnion;
using Domain.Errors.UnionErrorImplement.AccountUnionImplemnt;
using Domain.Untils;
using HotChocolate;
using Infrastructure.Services.UnitOfWorkService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account
{
    public class CreateAccountRequestHandler : IRequestHandler<CreateAccountRequest, MutationPayload<CreateAccountRequest,CreateAccountError>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAccountRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MutationPayload<CreateAccountRequest, CreateAccountError>> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
        {
            var transaction = await _unitOfWork.BeginTransactionAsync();

            

            try
            {
                var erros = new List<CreateAccountError>();

                var checkEmail = _unitOfWork.accountRepository.CheckEmail(request.Email!);

                if (checkEmail)
                {
                    erros.Add(new AccountExist());

                    return new MutationPayload<CreateAccountRequest, CreateAccountError>
                    {
                        errors = erros
                    };
                }

                var account = new AccountEntity
                {
                    Id = request.Id,
                    Email = request.Email,
                    LoginType = Domain.Enums.EnumLogin.None,
                    HashPassword = Hash.GenerateHash(request.Password!),
                    RoleId = 1,
                };

                var user = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    AccountId = account.Id,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    FullName = request.FirstName + " " + request.LastName,

                };

                await _unitOfWork.accountRepository.AddOneAsync(account);

                await _unitOfWork.userRepository.AddOneAsync(user);


                await _unitOfWork.SaveChangesAsync(cancellationToken);

                await transaction.CommitAsync(cancellationToken);

                return new MutationPayload<CreateAccountRequest, CreateAccountError>
                {
                    payload = request
                };

            }
            catch (Exception)
            {

                await transaction.RollbackAsync();

                throw;
            }
        }
    }
}
