using Domain.Interfaces.EntityBase;
using Domain.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.RepositoryBase
{
    public interface ICommentRepository<TEntity>:IRepository<TEntity> where TEntity : class,IEntity
    {
       
        public IQueryable<TComment> GetCommentByLessonId<TComment>(Guid lessonid) where TComment : IComment;
    }
}
