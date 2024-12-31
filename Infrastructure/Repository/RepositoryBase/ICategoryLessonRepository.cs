using Domain.Interfaces.EntityBase;
using Domain.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.RepositoryBase
{
    public interface ICategoryLessonRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public  Task<IEnumerable<TCategoryLesson>> GetCategoryLessonByIds<TCategoryLesson>(IReadOnlyList<Guid> keys, CancellationToken cancellation = default) where TCategoryLesson : class, ICategoryLesson;
        public IQueryable<TCategoryLesson> GetCategoryLessonByCourseId<TCategoryLesson>(Guid id) where TCategoryLesson : class, ICategoryLesson;


    }
}
