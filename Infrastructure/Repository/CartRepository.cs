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
    public class CartRepository : AbstractRepository<CartEntity, ApplicationDBContext>, ICartRepository<CartEntity>
    {
        public CartRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }

        public async Task<CartEntity?> GetCartDetailAsync(Guid id)
        {
            return await dBContext.Set<CartEntity>().Where(x => x.Id == id)
                .Include(x => x.courseEntity).FirstOrDefaultAsync();
        }

        public async Task<TCart?> GetCartById<TCart>(Guid id,CancellationToken cancellation = default)
        {
            var config = new MapperConfiguration(x=>x.CreateProjection<CartEntity,TCart>());

            return await dBContext.Set<CartEntity>().Where(x=>x.Id==id).AsNoTracking()
                .ProjectTo<TCart>(config).FirstOrDefaultAsync( cancellation);
        }

        public async Task<IEnumerable<TCart>> GetCartsByUerId<TCart>(Guid Id,int skip,int limit,CancellationToken cancellation = default) where TCart : class, ICart
        {
            var config = new MapperConfiguration(x => x.CreateProjection<CartEntity, TCart>());

            return await this.dBContext.Set<CartEntity>()
                .Where(x=>x.UserId == Id).AsNoTracking()
                .ProjectTo<TCart>(config).Skip(skip).Take(limit).ToListAsync(cancellation);
        }
        
    }
}
