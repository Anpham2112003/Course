using Domain.Entities;
using Domain.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.RepositoryBase
{
    public interface IConversationRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public Task<UserConversation?> CheckHasConversation(Guid id1, Guid id2);
    }
}
