using Domain.Entities;
using Infrastructure.DB.SQLDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure.Repository.RepositoryBase;


using Domain.Schemas;
namespace Infrastructure.Repository
{
    public class UserRepository : AbstractRepository<UserEntity, ApplicationDBContext>, IUserRepository<UserEntity>
    {

        public UserRepository(ApplicationDBContext dBContext) : base(dBContext)
        {

        }

        public async Task<UserEntity?> FindUserByAccountIdAsync(Guid accountId, CancellationToken cancellation = default)
        {
            return await dBContext.Set<UserEntity>().FirstOrDefaultAsync(x => x.AccountId == accountId, cancellation);
        }

        public async Task<IEnumerable<TUser>> GetUserByIds<TUser>(IReadOnlyList<Guid> keys, CancellationToken cancellation = default) where TUser:class,IUser
        {
            var config = new MapperConfiguration(x => x.CreateProjection<UserEntity, TUser>());

            return await dBContext.Set<UserEntity>().Where(x => keys.Contains(x.Id))
                .AsNoTracking()
                .ProjectTo<TUser>(config).ToListAsync(cancellation);
        }
       
    }
}
