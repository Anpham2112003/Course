
using Domain.Interfaces.Mailer;
using Domain.Types.ErrorTypes.Erros.Account;
using Domain.Types.ErrorTypes.Unions.Account;
using Domain.Untils;
using HotChocolate;
using Infrastructure.Services.MailService;
using Infrastructure.Unit0fWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;

namespace Application.MediaR.Comands.Account
{
    public class ForgotPasswordRequestHandler : IRequestHandler<ForgotPasswordRequest, MutationPayload<string, ForgetPassowordError>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMailerService _mailerService;
        public ForgotPasswordRequestHandler(IUnitOfWork unitOfWork, IMailerService mailerService)
        {
            _unitOfWork = unitOfWork;
            _mailerService = mailerService;
            
        }

        public async Task<MutationPayload<string, ForgetPassowordError>> Handle(ForgotPasswordRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var errors = new List<ForgetPassowordError>();

                var account = await _unitOfWork.accountRepository.FindAccountByEmailAsync(request.Email!,cancellationToken);

                if (account is null)
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


                BackgroundJob.Enqueue<IMailerService>(x => x.SendMailAsync(new MailObject()
                {
                    To = account.Email,
                    Subject = "Password reset",
                    Body = hashpassword,
                }, cancellationToken));

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
