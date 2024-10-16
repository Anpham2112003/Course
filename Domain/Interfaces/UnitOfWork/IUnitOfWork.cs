using Domain.Entities;
using Domain.Interfaces.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public DbContext GetContext();
        public Task<IDbContextTransaction> BeginTransactionAsync();
        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
        public Task<int> SaveChanges();
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);



        public IAccountRepository<AccountEntity> accountRepository { get; }
        public IUserRepository<UserEntity> userRepository { get; }
    }
}
