using Domain.Entities;
using Domain.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.RepositoryBase
{
    public interface IAccountRepository<TEnity> : IRepository<TEnity> where TEnity : class, IEntity
    {
        public Task<bool> CheckEmail(string email);
        public Task<AccountEntity?> FindAccountByEmailAsync(string email, CancellationToken cancellationToken = default);

        public Task<AccountEntity?> FindAccountAndRoleAsync(Expression<Func<AccountEntity, bool>> expression, CancellationToken cancellationToken = default);
    }
}
