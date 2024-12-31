using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.DTOs;
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
        public PurchaseRepository(ApplicationDBContext dBContext, IMapper mapper) : base(dBContext, mapper)
        {
        }

        public async Task<bool> CheckPurchaseCourse(Guid UserId, Guid CourseId)
        {
            return await dBContext.Set<PurchaseEntity>()
                .Where(x => x.UserId == UserId && x.CourseId == CourseId)
                .AnyAsync();
        }

        public async Task<IEnumerable<TPurchase>>  GetPurchaseByIds<TPurchase>(IReadOnlyList<Guid> keys , CancellationToken cancellation=default) where TPurchase:class,IPurchase
        {
            
            return await dBContext.Set<PurchaseEntity>()
                .Where(x=>keys.Contains(x.Id))
                .AsNoTracking()
                .ProjectTo<TPurchase>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellation);
        }

        public IQueryable<TPurchase> GetPurchaseByUserId<TPurchase>(Guid id) where TPurchase : class, IPurchase
        {
           
            return dBContext.Set<PurchaseEntity>()
                .Where(x => x.UserId==id)
                .AsNoTracking()
                .ProjectTo<TPurchase>(_mapper.ConfigurationProvider);
        }

        public async Task<bool> CheckPurchased(Guid userId,Guid courseId ,CancellationToken cancellation = default)
        {
            return await dBContext.Set<PurchaseEntity>()
                .Where(x =>x.UserId==userId&&x.CourseId==courseId)
                .AnyAsync(cancellation);
        }

        public async Task<int> GetTotalPurchaseByCourseId(Guid courseId, CancellationToken cancellation = default)
        {
            return await this.dBContext.Set<PurchaseEntity>()
                .Where(x=>x.CourseId == courseId)
                .CountAsync(cancellation);
        }
    }
}
