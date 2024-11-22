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
    public class TagRepository : AbstractRepository<TagEntity, ApplicationDBContext>, ITagRepository<TagEntity>
    {
        public TagRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }

        

        public Task<TagEntity?> FindTagByIdOrNameAsync(int id, string name)
        {
            return dBContext.Set<TagEntity>().FirstOrDefaultAsync(x => x.Id == id || x.Name == name);
        }

        public async Task<bool> HasTagName(string tagName)
        {
            return await dBContext.Set<TagEntity>().AnyAsync(x => x.Name == tagName);
        }

       

        public async Task<int> CountCourseByTag(int tagId, CancellationToken cancellation=default)
        {
            return await dBContext.Set<CourseTag>().CountAsync(x => x.TagId == tagId,cancellation);
        }

        public async Task<IEnumerable<TCourse>> GetCoursesByTagId<TCourse>(int id, int skip, int limit,CancellationToken cancellation=default) where TCourse : class, ICourse
        {
            var config = new MapperConfiguration(x => x.CreateProjection<CourseEntity, TCourse>());

            return await this.dBContext.Set<TagEntity>()
                .Include(x=>x.courseEntities)
                .SelectMany(x=>x.courseEntities)
                .AsNoTracking()
                .ProjectTo<TCourse>(config)
                .Skip(skip).Take(limit).ToListAsync(cancellation);
        }

        public async Task<IEnumerable<TTag>> GetTagByIds<TTag>(IReadOnlyList<int> keys, CancellationToken cancellation = default)
        {
            var cogfig = new MapperConfiguration(x=>x.CreateProjection<TagEntity, TTag>());

            return await this.dBContext.Set<TagEntity>()
                .Where(x=>keys.Contains(x.Id)).AsNoTracking()
                .ProjectTo<TTag>(cogfig).ToListAsync(cancellation);
        }
    }
}
