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
        public TagRepository(ApplicationDBContext dBContext, IMapper mapper) : base(dBContext, mapper)
        {
        }

        public Task<TagEntity?> FindTagByIdOrNameAsync(int id, string name)
        {
            return dBContext.Set<TagEntity>()
                .FirstOrDefaultAsync(x => x.Id == id || x.Name == name);
        }

        public async Task<bool> HasTagName(string tagName)
        {
            return await dBContext.Set<TagEntity>()
                .AnyAsync(x => x.Name == tagName);
        }

       

        public async Task<int> CountCourseByTag(int tagId, CancellationToken cancellation=default)
        {
            return await dBContext.Set<CourseTag>()
                .CountAsync(x => x.TagId == tagId,cancellation);
        }

        public IQueryable<TCourse> GetCoursesByTagId<TCourse>(int id) where TCourse : class, ICourse
        {

            return  this.dBContext.Set<TagEntity>()
                .Include(x=>x.courseEntities)
                .SelectMany(x=>x.courseEntities)
                .AsNoTracking()
                .ProjectTo<TCourse>(_mapper.ConfigurationProvider);
        }

        public async Task<IEnumerable<TTag>> GetTagByIds<TTag>(IReadOnlyList<int> keys, CancellationToken cancellation = default)
        {
           

            return await this.dBContext.Set<TagEntity>()
                .Where(x=>keys.Contains(x.Id)).AsNoTracking()
                .ProjectTo<TTag>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellation);
        }

        public async Task<IEnumerable<TTag>> GetTags<TTag>(CancellationToken cancellation=default) where TTag : ITag
        {


            return await this.dBContext.Set<TagEntity>()
                .ProjectTo<TTag>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellation);
        }
    }
}
