using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.Schemas;
using HotChocolate.Data;
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
    public class PurchaseRepository : AbstractRepository<PurchaseEntity, ApplicationDBContext>, IPurchaseRepository<PurchaseEntity>
    {
        public PurchaseRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }

        public async Task<bool> CheckPurchaseCourse(Guid UserId, Guid CourseId)
        {
            return await dBContext.Set<PurchaseEntity>().Where(x => x.UserId == UserId && x.CourseId == CourseId).AnyAsync();
        }

        public async Task<IEnumerable<TPurchase>>  GetPurchaseByIds<TPurchase>(IReadOnlyList<Guid> keys , CancellationToken cancellation=default) where TPurchase:class,IPurchase
        {
            var config = new MapperConfiguration(x=>x.CreateProjection<PurchaseEntity,TPurchase>());
            
            return await dBContext.Set<PurchaseEntity>().Where(x=>keys.Contains(x.Id))
                .AsNoTracking().ProjectTo<TPurchase>(config).ToListAsync(cancellation);
        }
    }
}
