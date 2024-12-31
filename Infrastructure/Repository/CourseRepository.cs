using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Infrastructure.DB.SQLDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Schemas;
using Infrastructure.Repository.RepositoryBase;
using System.Threading;
using HotChocolate.Data;
using HotChocolate.Resolvers;
using Domain.Interfaces.EntityBase;

namespace Infrastructure.Repository
{
    public class CourseRepository : AbstractRepository<CourseEntity, ApplicationDBContext>, ICourseRepository<CourseEntity>
    {
        public CourseRepository(ApplicationDBContext dBContext, IMapper mapper) : base(dBContext, mapper)
        {
        }

        public async Task<bool> HasCourse(Guid Id)
        {
            return await dBContext.Set<CourseEntity>()
                .AnyAsync(x => x.Id == Id && x.IsDeleted == false && x.IsPublish == true);
        }

        public IQueryable<TQuery> AsQueryableType<TQuery>() where TQuery : class,ICourse
        {
            return this.dBContext.Set<CourseEntity>().ProjectTo<TQuery>(_mapper.ConfigurationProvider).AsQueryable();
        }

        public async Task<IEnumerable<TCourse>> GetCourseByIds<TCourse>(IReadOnlyList<Guid> keys,CancellationToken cancellationToken = default)
        {
           

            return await this.dBContext.Set<CourseEntity>()
                .Where(x => keys.Contains(x.Id))
                .AsNoTracking().ProjectTo<TCourse>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        public IQueryable<TCourse> GetCoursesByUserId<TCourse>(Guid Id) where TCourse : class,ICourse
        {

            return  this.dBContext.Set<CourseEntity>()
                .Where(x => x.AuthorId == Id)
                .AsNoTracking()
                .ProjectTo<TCourse>(_mapper.ConfigurationProvider);
        }

        public async Task<IEnumerable<TTag>> GetTagsByCourseId<TTag>(Guid CourseId,CancellationToken cancellation=default) where TTag:class,ITag
        {

            return await this.dBContext.Set<CourseEntity>()
                .Where(x => x.Id == CourseId)
                .SelectMany(x => x.tagEntities)
                .AsNoTracking()
                .ProjectTo<TTag>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellation);
        }

        public async Task<IEnumerable<TTopic>>GetTopicsByCourseId<TTopic>(Guid CourseId, CancellationToken cancellation=default) where TTopic:class,ITopic
        {
            
            return await this.dBContext.Set<CourseEntity>()
                .Where(x=>x.Id == CourseId)
                .SelectMany(x=>x.topicEntities)
                .AsNoTracking()
                .ProjectTo<TTopic>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellation);
        }


        public async Task<int> CountCourseByUserId(Guid Id,CancellationToken cancellation)
        {
            return await this.dBContext.Set<CourseEntity>()
                .Where(x=>x.AuthorId == Id)
                .CountAsync(cancellation);
        }

        
    }
}
