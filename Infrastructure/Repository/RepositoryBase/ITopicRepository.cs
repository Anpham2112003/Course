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
    public interface ITopicRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public Task<bool> HasTopicName(string topicName);
        public  Task<int> CountCourseByTopicId(int Id,CancellationToken cancellation=default);
        public  Task<bool> HasTopicCourse(int TopicId, Guid CourseId);
        public  Task AddTopicCourse(CourseTopic courseTopic);
        public  Task<CourseTopic?> FindTopicCourse(int ToppicId, Guid CourseId,CancellationToken cancellation=default);
        public void DeleteTopicCourse(CourseTopic courseTopic);
        public  Task<IEnumerable<TTopic>> GetTopicByIds<TTopic>(IReadOnlyList<int> keys, CancellationToken cancellation = default) where TTopic : class, ITopic;
        public IQueryable<TCourse> GetCoursesByTopicId<TCourse>(int id) where TCourse : class, ICourse;
        public Task<IEnumerable<TTopic>> GetTopics<TTopic>(CancellationToken cancellation = default) where TTopic : class, ITopic;
    }
}
