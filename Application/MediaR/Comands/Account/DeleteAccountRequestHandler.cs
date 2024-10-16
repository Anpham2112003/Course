
using Domain.Interfaces.Mailer;
using Domain.Interfaces.UnitOfWork;
using Domain.Types.ErrorTypes.BaseError.AccountUnion;
using Domain.Types.ErrorTypes.ErrorImplement.AccountErrors;
using Domain.Untils;
using Infrastructure.Services.MailService;
using Infrastructure.Services.RepositoryService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Account
{
    public class DeleteAccountRequestHandler : IRequestHandler<DeleteAccountRequest, MutationPayload<string, DeleteAccountError>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMailerService _mailerService;

        public DeleteAccountRequestHandler(IUnitOfWork unitOfWork, IMailerService mailerService)
        {
            _unitOfWork = unitOfWork;
            _mailerService = mailerService;
        }

        public async Task<MutationPayload<string, DeleteAccountError>> Handle(DeleteAccountRequest request, CancellationToken cancellationToken)
        {
            var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                var errors = new List<DeleteAccountError>();

                var account = await _unitOfWork.accountRepository.FindAccountByEmailAsync(request.Email!);

                if (account is null)
                {
                    errors.Add(new AccountOrPasswordError());

                    return new MutationPayload<string, DeleteAccountError>
                    {
                        errors = errors,
                    };
                }

                if (account.IsDeleted)
                {
                    errors.Add(new AccountHasDeleted());

                    return new MutationPayload<string, DeleteAccountError>
                    {
                        errors = errors,
                    };
                }

                var user = await _unitOfWork.userRepository.FirstAsync(x => x.AccountId == account.Id);

                user!.IsDeleted = true;

                account.IsDeleted = true;


                _unitOfWork.accountRepository.UpdateOne(account);

                _unitOfWork.userRepository.UpdateOne(user);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                await transaction.CommitAsync();

                var sendMail = _mailerService.SendMailAsync(new MailObject
                {
                    Subject = "Account has been deleted",
                    To = request.Email,
                    Body = "Account has been deleted!"
                }, cancellationToken);



                return new MutationPayload<string, DeleteAccountError>
                {
                    payload = request.Email,

                };
            }
            catch (Exception)
            {
                transaction.Rollback();

                throw;
            }
        }
    }
}
