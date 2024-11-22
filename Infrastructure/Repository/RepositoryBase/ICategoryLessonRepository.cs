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
        public  Task<TCategoryLesson?> GetCategoryLessonById<TCategoryLesson>(Guid Id, CancellationToken cancellation = default) where TCategoryLesson : class, ICategoryLesson;
    }
}
