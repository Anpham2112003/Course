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
        public CartRepository(ApplicationDBContext dBContext, IMapper mapper) : base(dBContext, mapper)
        {
        }

        public async Task<CartEntity?> GetCartDetailAsync(Guid id)
        {
            return await dBContext.Set<CartEntity>()
                .Where(x => x.Id == id)
                .Include(x => x.courseEntity)
                .FirstOrDefaultAsync();
        }

        public async Task<TCart?> GetCartById<TCart>(Guid id,CancellationToken cancellation = default)
        {
            

            return await dBContext.Set<CartEntity>()
                .Where(x=>x.Id==id)
                .AsNoTracking()
                .ProjectTo<TCart>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync( cancellation);
        }

        public IQueryable<TCart> GetCartsByUerId<TCart>(Guid Id) where TCart : class, ICart
        {
           
            return  this.dBContext.Set<CartEntity>()
                .Where(x=>x.UserId == Id)
                .AsNoTracking()
                .ProjectTo<TCart>(_mapper.ConfigurationProvider);
        }
        
    }
}
