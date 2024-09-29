using ApplicationCore.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.RepositoryBase
{
    public interface IAccountRepository<TEnity>:IRepository<TEnity> where TEnity : class,IEntity
    {
    }
}
