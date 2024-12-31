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
    public class LessonRepository : AbstractRepository<LessonEntity, ApplicationDBContext>, ILessonRepository<LessonEntity>
    {
        public LessonRepository(ApplicationDBContext dBContext, IMapper mapper) : base(dBContext, mapper)
        {
        }

        public async Task<IEnumerable<TLesson>>GetLessonByIds<TLesson>(IReadOnlyList<Guid> keys,CancellationToken cancellation) where TLesson : class, ILesson
        {
          

            return await this.dBContext.Set<LessonEntity>()
                .Where(x => keys.Contains(x.Id))
                .AsNoTracking()
                .ProjectTo<TLesson>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellation);
        }

        public IQueryable<TLesson> GetLessonByCategoryLessonId<TLesson>(Guid id) where TLesson : class, ILesson
        {

            return  this.dBContext.Set<LessonEntity>()
                .Where(x =>x.CategoryLessonId==id)
                .AsNoTracking()
                .ProjectTo<TLesson>(_mapper.ConfigurationProvider) ;
        }
    }
}
