using Domain.Entities;
using Domain.Interfaces.EntityBase;
using Domain.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.RepositoryBase
{
    public interface ITagRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public Task<TagEntity?> FindTagByIdOrNameAsync(int id, string name);
        public Task<bool> HasTagName(string tagName);
        public Task<int> CountCourseByTag(int tagId,CancellationToken cancellation=default);
        public  IQueryable<TCourse> GetCoursesByTagId<TCourse>(int id) where TCourse : class, ICourse;
        public Task<IEnumerable<TTag>> GetTagByIds<TTag>(IReadOnlyList<int> keys, CancellationToken cancellation = default);
        public  Task<IEnumerable<TTag>> GetTags<TTag>(CancellationToken cancellation = default) where TTag : ITag;
    }
}
