using ApplicationCore.DTOs;
using ApplicationCore.Response;
using Domain.Entities;
using HotChocolate;
using HotChocolate.Types;
using Infrastructure.Services.UnitOfWorkService;

namespace Api.Mutation
{
    [ExtendObjectType(typeof(Mutations))]
    public class AccountMutation
    {
        
        public async Task<IResponse<AccountDTO>> createAccount([Service]IUnitOfWork unitOfWork,AccountDTO data)
        {
            var trans = await unitOfWork.BeginTransactionAsync();

            try
            {
               
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
