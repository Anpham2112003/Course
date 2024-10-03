using ApplicationCore.Interfaces.EntityBase;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.RepositoryBase
{
    public interface IAccountRepository<TEnity>:IRepository<TEnity> where TEnity : class,IEntity
    {
        public bool CheckEmail(string email);
        public  Task<AccountEntity?> FindAccountByEmailAsync(string email);
    }
}
