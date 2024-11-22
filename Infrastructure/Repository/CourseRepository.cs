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

namespace Infrastructure.Repository
{
    public class CourseRepository : AbstractRepository<CourseEntity, ApplicationDBContext>, ICourseRepository<CourseEntity>
    {
        public CourseRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }



        public async Task<bool> HasCourse(Guid Id)
        {
            return await dBContext.Set<CourseEntity>().AnyAsync(x => x.Id == Id && x.IsDeleted == false && x.IsPublish == true);
        }

        public async Task<IEnumerable<TCourse>> GetCourseByIds<TCourse>(IReadOnlyList<Guid> keys,CancellationToken cancellationToken = default)
        {
            var config = new MapperConfiguration(x => x.CreateProjection<CourseEntity, TCourse>());

            return await this.dBContext.Set<CourseEntity>()
                .Where(x => keys.Contains(x.Id)).AsNoTracking().ProjectTo<TCourse>(config).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TCourse>> GetCoursesByUserId<TCourse>(Guid Id, int skip,int take,CancellationToken cancellation=default) where TCourse : class,ICourse
        {
            var config = new MapperConfiguration(x => x.CreateProjection<CourseEntity, TCourse>());

            return await this.dBContext.Set<CourseEntity>().Where(x=>x.AuthorId == Id)
                .AsNoTracking()
                .ProjectTo<TCourse>(config).Skip(skip).Take(take).ToListAsync(cancellation);
        }

        public async Task<IEnumerable<TTag>> GetTagsByCourseId<TTag>(Guid CourseId,CancellationToken cancellation=default) where TTag:class,ITag
        {
            var config = new MapperConfiguration(x=>x.CreateMap<TagEntity, TTag>());

            return await this.dBContext.Set<CourseEntity>().Where(x => x.Id == CourseId)
                .SelectMany(x => x.tagEntities).AsNoTracking().ProjectTo<TTag>(config).ToListAsync(cancellation);
        }

        public async Task<IEnumerable<TTopic>>GetTopicsByCourseId<TTopic>(Guid CourseId, CancellationToken cancellation=default) where TTopic:class,ITopic
        {
            var config = new MapperConfiguration(x => x.CreateProjection<TopicEntity, TTopic>());

            return await this.dBContext.Set<CourseEntity>().Where(x=>x.Id == CourseId)
                .SelectMany(x=>x.topicEntities).AsNoTracking().ProjectTo<TTopic>(config).ToListAsync(cancellation);
        }
    }
}
