using Domain.Interfaces.EntityBase;
using Domain.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.RepositoryBase
{
    public interface ICourseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public Task<bool> HasCourse(Guid Id);
        public Task<IEnumerable<TCourse>> GetCoursesByUserId<TCourse>(Guid Id, int skip, int take, CancellationToken cancellation=default) where TCourse : class,ICourse;
        public Task<IEnumerable<TTag>> GetTagsByCourseId<TTag>(Guid CourseId, CancellationToken cancellation=default) where TTag : class, ITag;
        public Task<IEnumerable<TTopic>> GetTopicsByCourseId<TTopic>(Guid CourseId, CancellationToken cancellation=default) where TTopic : class, ITopic;
        public Task<IEnumerable<TCourse>> GetCourseByIds<TCourse>(IReadOnlyList<Guid> keys, CancellationToken cancellationToken = default);
        public IQueryable<TQuery> AsQueryableType<TQuery>() where TQuery : class, ICourse;

    }
}
