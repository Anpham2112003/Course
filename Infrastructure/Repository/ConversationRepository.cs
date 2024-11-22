using Domain.Entities;
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
        public ConversationRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }

        public async Task<UserConversation?> CheckHasConversation(Guid id1, Guid id2)
        {
            return await dBContext.Set<UserConversation>().Where(x => x.UserId == id1 && x.InboxId == id2 || x.UserId == id2 && x.InboxId == id1).FirstOrDefaultAsync();
        }
    }
}
