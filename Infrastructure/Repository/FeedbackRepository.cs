using Domain.DTOs;
using Domain.Entities;
using Infrastructure.DB.SQLDbContext;
using Infrastructure.Repository.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Schemas;

namespace Infrastructure.Repository
{
    public class FeedbackRepository : AbstractRepository<FeedbackEntity, ApplicationDBContext>, IFeedbackRepository<FeedbackEntity>
    {
        public FeedbackRepository(ApplicationDBContext dBContext, IMapper mapper) : base(dBContext, mapper)
        {
        }

        public async Task<bool> HasFeedback(Guid UserId, Guid CourseId)
        {
            return await dBContext.Set<FeedbackEntity>()
                .Where(x => x.UserId == UserId && x.CourseId == CourseId && x.IsDeleted == false)
                .AnyAsync();
        }

        public async Task<AverageRate?> TotalRate(Guid CourseId)
        {
            var result = await dBContext.Set<FeedbackEntity>()
                .Where(x => x.CourseId == CourseId && x.IsDeleted == false)
                .GroupBy(x => x.UserId).Select(x => new AverageRate
                {
                    TotalFeedback = x.Count(),
                    TotalRate = x.Sum(x => x.Rate)
                }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<TFeedBack>> GetFeedBackByIds<TFeedBack>(IReadOnlyList<Guid> keys, CancellationToken cancellationToken) where TFeedBack : class, IFeedback
        {

            return await dBContext.Set<FeedbackEntity>()
                .Where(x=>keys.Contains(x.Id))
                .ProjectTo<TFeedBack>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<TFeedBack>> GetFeedBackByCourseIds<TFeedBack>(Guid courseId,int skip,int limit, CancellationToken cancellationToken) where TFeedBack : class, IFeedback
        {
           
            return await dBContext.Set<FeedbackEntity>()
                .Where(x=>x.CourseId==courseId)
                .ProjectTo<TFeedBack>(_mapper.ConfigurationProvider)
                .Skip(skip).Take(limit)
                .ToListAsync(cancellationToken);
        }
    }
}
