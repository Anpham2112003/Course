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
    public class CategoryLessonRepository : AbstractRepository<CategoryLessonEntity, ApplicationDBContext>, ICategoryLessonRepository<CategoryLessonEntity>
    {
        public CategoryLessonRepository(ApplicationDBContext dBContext, IMapper mapper) : base(dBContext, mapper)
        {
        }

        public async Task<IEnumerable<TCategoryLesson>> GetCategoryLessonByIds<TCategoryLesson>(IReadOnlyList<Guid> keys ,CancellationToken cancellation=default) where TCategoryLesson : class, ICategoryLesson
        {
            

            return await this.dBContext.Set<CategoryLessonEntity>()
                .Where(x => keys.Contains(x.Id)).AsNoTracking()
                .ProjectTo<TCategoryLesson>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellation);
        }

        public async Task<IEnumerable<TCategoryLesson>> GetCategoryLessonByCourseId<TCategoryLesson>(Guid id,int skip,int limit, CancellationToken cancellation = default) where TCategoryLesson : class, ICategoryLesson
        {

            return await this.dBContext.Set<CategoryLessonEntity>().Where(x =>x.CourseId==id)
                .AsNoTracking()
                .ProjectTo<TCategoryLesson>(_mapper.ConfigurationProvider)
                .Skip(skip).Take(limit)
                .ToListAsync(cancellation);
        }
    }
}
