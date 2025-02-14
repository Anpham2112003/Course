﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.Schemas;
using HotChocolate.Data;
using Infrastructure.DB.SQLDbContext;
using Infrastructure.Repository.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class TopicRepository : AbstractRepository<TopicEntity, ApplicationDBContext>, ITopicRepository<TopicEntity>
    {
        public TopicRepository(ApplicationDBContext dBContext, IMapper mapper) : base(dBContext, mapper)
        {
        }

        public async Task<bool> HasTopicName(string topicName)
        {
            return await dBContext.Set<TopicEntity>().AnyAsync(x => x.Name == topicName);
        }

        public async Task<bool> HasTopicCourse(int TopicId,Guid CourseId)
        {
            return await this.dBContext.Set<CourseTopic>().AnyAsync(x=>x.TopicId==TopicId && x.CourseId==CourseId);
        }

        

        public async Task<int> CountCourseByTopicId(int Id, CancellationToken cancellation=default)
        {
            return await this.dBContext.Set<CourseTopic>().CountAsync(x=>x.TopicId == Id,cancellation);
        }

       

        public async Task AddTopicCourse(CourseTopic courseTopic)
        {
            await this.dBContext.Set<CourseTopic>().AddAsync(courseTopic);
        }

        public async Task<CourseTopic?> FindTopicCourse(int ToppicId,Guid CourseId,CancellationToken cancellation=default)
        {
            return await this.dBContext.Set<CourseTopic>()
                .FirstOrDefaultAsync(x=>x.TopicId==ToppicId&&x.CourseId==CourseId);
        }

        public void DeleteTopicCourse(CourseTopic courseTopic)
        {
             this.dBContext.Set<CourseTopic>().Remove(courseTopic);
        }

        public async Task<IEnumerable<TTopic>> GetTopicByIds<TTopic>(IReadOnlyList<int> keys, CancellationToken cancellation=default) where TTopic:class,ITopic
        {
          

            return await this.dBContext.Set<TopicEntity>().Where(x=>keys.Contains(x.Id))
                .AsNoTracking()
                .ProjectTo<TTopic>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellation);
        }

        public IQueryable<TCourse> GetCoursesByTopicId<TCourse>(int id) where TCourse : class, ICourse
        {

            return this.dBContext.Set<TopicEntity>()
                .Include(x => x.courseEntities)
                .SelectMany(x => x.courseEntities)
                .AsNoTracking()
                .ProjectTo<TCourse>(_mapper.ConfigurationProvider);
        }

        public async Task<IEnumerable<TTopic>> GetTopics<TTopic>(CancellationToken cancellation=default) where TTopic : class, ITopic
        {

            return await this.dBContext.Set<TopicEntity>()
                .AsNoTracking()
                .ProjectTo<TTopic>(_mapper.ConfigurationProvider).ToListAsync(cancellation);
        }
    }
}
