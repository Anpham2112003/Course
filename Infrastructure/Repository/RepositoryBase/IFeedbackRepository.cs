using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Schemas;

namespace Infrastructure.Repository.RepositoryBase
{
    public interface IFeedbackRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public Task<bool> HasFeedback(Guid UserId, Guid CourseId);
        public Task<AverageRate?> TotalRate(Guid CourseId,CancellationToken cancellation=default);
        
        public Task<List<TFeedBack>> GetFeedBackByIds<TFeedBack>(IReadOnlyList<Guid> keys , CancellationToken cancellationToken=default) where TFeedBack : class, IFeedback;

        public IQueryable<TFeedBack> GetFeedBackByCourseIds<TFeedBack>(Guid courseId) where TFeedBack : class, IFeedback;


    }
}
