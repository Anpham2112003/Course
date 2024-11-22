
using Domain.Types.ErrorTypes.Erros.Account;
using Domain.Types.ErrorTypes.Unions.Account;
using Domain.Untils;
using HotChocolate.AspNetCore;
using Infrastructure.Unit0fWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Account
{
    public class ResetPasswordRequestHandler : IRequestHandler<ResetPasswordRequest, MutationPayload<ResetPasswordRequest, ResetPasswordError>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResetPasswordRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MutationPayload<ResetPasswordRequest, ResetPasswordError>> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
        {


            try
            {
                var erros = new List<ResetPasswordError>();

                var account = await _unitOfWork.accountRepository.FindAccountByEmailAsync(request.Email!);

                if (account is null || account.IsDeleted is true || Hash.VerifyHash(account.HashPassword!, request.OldPassword!))
                {
                    erros.Add(new AccountOrPasswordError());

                    return new MutationPayload<ResetPasswordRequest, ResetPasswordError>
                    {
                        errors = erros
                    };
                }

                if (account.IsDeleted)
                {
                    erros.Add(new AccountHasDeleted());

                    return new MutationPayload<ResetPasswordRequest, ResetPasswordError>
                    {
                        errors = erros
                    };
                }

                var hashPassword = Hash.GenerateHash(request.NewPassword!);

                account.HashPassword = hashPassword;

                _unitOfWork.accountRepository.UpdateOne(account);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<ResetPasswordRequest, ResetPasswordError>
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
