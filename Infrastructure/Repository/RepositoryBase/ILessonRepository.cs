﻿using Domain.Interfaces.EntityBase;
using Domain.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.RepositoryBase
{
    public interface ILessonRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public  Task<IEnumerable<TLesson>> GetLessonByIds<TLesson>(IReadOnlyList<Guid> keys, CancellationToken cancellation) where TLesson : class, ILesson;
        public IQueryable<TLesson> GetLessonByCategoryLessonId<TLesson>(Guid id) where TLesson : class, ILesson;
    }
}
