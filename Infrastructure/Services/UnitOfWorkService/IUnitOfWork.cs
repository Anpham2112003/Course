using ApplicationCore.Interfaces.RepositoryBase;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.UnitOfWorkService
{
    public interface IUnitOfWork:IDisposable
    {
        public Task<IDbContextTransaction> BeginTransactionAsync();
        public Task< IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
        public Task<int> SaveChanges();
        public Task<int> SaveChanges(CancellationToken cancellationToken);



        public IAccountRepository<AccountEntity> accountRepository { get; }
    }
}
