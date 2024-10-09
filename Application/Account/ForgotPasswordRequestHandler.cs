
using ApplicationCore.Untils;
using Domain.Errors;
using Domain.Errors.UnionError.AccountUnion;
using Domain.Errors.UnionErrorImplement.AccountUnionImplemnt;
using Domain.Untils;
using HotChocolate;
using Infrastructure.Services.MailService;
using Infrastructure.Services.UnitOfWorkService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account
{
    public class ForgotPasswordRequestHandler : IRequestHandler<ForgotPasswordRequest, MutationPayload<string,ForgetPassowordError>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMailerService _mailerService;
        private readonly IPublisher publisher;
        public ForgotPasswordRequestHandler(IUnitOfWork unitOfWork, IMailerService mailerService, IPublisher publisher)
        {
            _unitOfWork = unitOfWork;
            _mailerService = mailerService;
            this.publisher = publisher;
        }

        public async Task<MutationPayload<string, ForgetPassowordError>> Handle(ForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            
            try
            {
                var errors = new List<ForgetPassowordError>();

                var account = await _unitOfWork.accountRepository.FindAccountByEmailAsync(request.Email!);

                if (account is null )
                {
                    errors.Add(new AccountNotFound());

                    return new MutationPayload<string, ForgetPassowordError>
                    {
                        errors = errors
                    };
                }

                if (account.IsDeleted)
                {
                    errors.Add(new AccountHasDeleted());

                    return new MutationPayload<string, ForgetPassowordError>
                    {
                        errors = errors
                    };
                }

                var password = Guid.NewGuid().ToString();

                var hashpassword = Hash.GenerateHash(password);
                
                
                var task = _mailerService.SendMailAsync(new MailObject
                {
                    To = request.Email,
                    Body = password,
                    Subject = "New Password"
                },cancellationToken);

                account.HashPassword = hashpassword;

                _unitOfWork.accountRepository.UpdateOne(account);
               
                await _unitOfWork.SaveChangesAsync(cancellationToken);
               
                return new MutationPayload<string, ForgetPassowordError>
                {
                    payload = request.Email,
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
