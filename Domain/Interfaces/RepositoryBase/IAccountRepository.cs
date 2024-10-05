using ApplicationCore.Interfaces.EntityBase;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.RepositoryBase
{
    public interface IAccountRepository<TEnity>:IRepository<TEnity> where TEnity : class,IEntity
    {
        public bool CheckEmail(string email);
        public  Task<AccountEntity?> FindAccountByEmailAsync(string email,CancellationToken cancellationToken=default);

        public Task<AccountEntity?> FindAccountAndRoleAsync(Expression<Func<AccountEntity, bool>> expression, CancellationToken cancellationToken = default);
    }
}
