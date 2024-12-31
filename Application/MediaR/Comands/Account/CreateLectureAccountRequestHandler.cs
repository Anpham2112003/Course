using Domain.Entities;
using Domain.Types.EnumTypes;
using Domain.Types.ErrorTypes.Erros.Account;
using Domain.Types.ErrorTypes.Unions.Account;
using Domain.Untils;
using Infrastructure.Unit0fWork;
using MediatR;

namespace Application.MediaR.Comands.Account;

public class CreateLectureAccountRequestHandler:IRequestHandler<CreateLectureAccountRequest,MutationPayload<CreateLectureAccountRequest,CreateAccountError>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateLectureAccountRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<MutationPayload<CreateLectureAccountRequest, CreateAccountError>> Handle(CreateLectureAccountRequest request, CancellationToken cancellationToken)
    {
        var errors = new List<CreateAccountError>();
        
        var trans = await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var checkEmail = await _unitOfWork.accountRepository.CheckEmail(request.Email!);

            if (checkEmail)
            {
                errors.Add(new AccountExist());

                return new MutationPayload<CreateLectureAccountRequest, CreateAccountError>()
                {
                    errors = errors
                };
            }

            var account = new AccountEntity()
            {
                Id = request.Id,
                Email = request.Email,
                HashPassword = Hash.GenerateHash(request.Password!),
                LoginType = EnumLogin.None,
                RoleId = 2
            };

            var user = new UserEntity()
            {
                Id = Guid.NewGuid(),
                AccountId = account.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                FullName = request.FirstName + " " + request.LastName,

            };

            var tk1 =  _unitOfWork.accountRepository.AddOneAsync(account, cancellationToken);
            var tk2 = _unitOfWork.userRepository.AddOneAsync(user, cancellationToken);
            
            await Task.WhenAll(tk1, tk2);
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            await trans.CommitAsync(cancellationToken);

            return new MutationPayload<CreateLectureAccountRequest, CreateAccountError>()
            {
                payload = request
            };

        }
        catch (Exception e)
        {
            await trans.RollbackAsync();
            Console.WriteLine(e);
            throw;
        }
    }
}