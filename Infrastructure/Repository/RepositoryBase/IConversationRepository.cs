using Domain.Entities;
using Domain.Interfaces.EntityBase;
using Domain.Schemas;
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
        public Task<IEnumerable<TConversation>> GetConversationByIdUser<TConversation>(Guid id, int skip, int limit, CancellationToken cancellation=default) where TConversation : class, IConversation;
        public Task<TConversation?> GetOrInitConversation<TConversation>(Guid myId, Guid refId, CancellationToken cancellation = default) where TConversation : class, IConversation;
        public Task<IEnumerable<TUser>> GetUserInConversation<TUser>(Guid conversationId, CancellationToken cancellation = default) where TUser : class, IUser;
        public Task AddUserConversations(IEnumerable<UserConversation> conversations);
        public Task<bool> CheckInConversation(Guid id, Guid conversationId, CancellationToken cancellation = default);
       
    }
}
