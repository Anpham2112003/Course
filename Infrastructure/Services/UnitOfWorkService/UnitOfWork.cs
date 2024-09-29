using ApplicationCore.Interfaces.RepositoryBase;
using Domain.Entities;
using Infrastructure.DB.SQLDbContext;
using Infrastructure.Services.RepositoryService;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Services.UnitOfWorkService
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _dbContext;

        public UnitOfWork(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
        {
           return await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }

       
        public async Task<int> SaveChanges(CancellationToken cancellationToken)
        {
           return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {

        }


        //////////////////////////*****************/////////////////////////

        public IAccountRepository<AccountEntity> accountRepository 

            =>  new AccountRepostitory(_dbContext);
    }
}
