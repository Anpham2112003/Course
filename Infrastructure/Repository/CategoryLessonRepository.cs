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
        public CategoryLessonRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }

        public async Task<TCategoryLesson?> GetCategoryLessonById<TCategoryLesson>(Guid Id ,CancellationToken cancellation=default) where TCategoryLesson : class, ICategoryLesson
        {
            var config = new MapperConfiguration(x => x.CreateProjection<CategoryLessonEntity, TCategoryLesson>());

            return await this.dBContext.Set<CategoryLessonEntity>().Where(x => x.Id == Id).AsNoTracking()
                .ProjectTo<TCategoryLesson>(config).FirstOrDefaultAsync(cancellation);
        }
    }
}
