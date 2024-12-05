using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.Schemas;
using Infrastructure.DB.SQLDbContext;
using Infrastructure.Repository.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ConversationRepository : AbstractRepository<ConversationEntity, ApplicationDBContext>, IConversationRepository<ConversationEntity>
    {
        public ConversationRepository(ApplicationDBContext dBContext, IMapper mapper) : base(dBContext, mapper)
        {
        }

        public async Task<UserConversation?> CheckHasConversation(Guid id1, Guid id2)
        {
            return await dBContext.Set<UserConversation>()
                .Where(x => x.UserId == id1 && x.InboxId == id2 || x.UserId == id2 && x.InboxId == id1)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TConversation>> GetConversationByIdUser<TConversation>(Guid id,int skip,int limit,CancellationToken cancellation=default) where TConversation : class,IConversation
        {

            return await this.dBContext.Set<UserEntity>()
                .Where(x=>x.Id==id)
                .SelectMany(x=>x.conversationEntities)
                .ProjectTo<TConversation>(_mapper.ConfigurationProvider)
                .Skip(skip).Take(limit)
                .ToListAsync(cancellation);
        }


        public async Task<TConversation?> GetOrInitConversation<TConversation>(Guid myId, Guid refId,CancellationToken cancellation=default) where TConversation: class,IConversation
        {
            
            return await this.dBContext.Set<UserConversation>()
                .Where(x=>(x.UserId==myId&&x.InboxId==refId) || (x.UserId==refId&&x.InboxId==myId))
                .Include(x=>x.conversationEntity)
                .Select(x=>x.conversationEntity)
                .ProjectTo<TConversation>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellation);
        }


        public async Task<IEnumerable<TUser>> GetUserInConversation<TUser>(Guid conversationId,CancellationToken cancellation = default) where TUser:class,IUser
        {

            return await this.dBContext.Set<ConversationEntity>()
                .Where(x => x.Id == conversationId)
                .Include(x => x.userEntities)
                .SelectMany(x => x.userEntities)
                .ProjectTo<TUser>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellation);
        }

        public async Task AddUserConversations(IEnumerable<UserConversation> conversations)
        {
            await this.dBContext.Set<UserConversation>()
                .AddRangeAsync(conversations);
        }


        public async Task<bool> CheckInConversation(Guid id , Guid conversationId,CancellationToken cancellation=default)
        {
            return await this.dBContext.Set<UserConversation>()
                .Where(x => (x.InboxId == id && x.ConversationId == conversationId) || (x.UserId == id && x.ConversationId == conversationId))
                .AnyAsync();
        }

        
    }
}
