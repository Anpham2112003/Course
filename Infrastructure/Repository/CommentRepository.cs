using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.Schemas;
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
    public class CommentRepository : AbstractRepository<CommentEntity, ApplicationDBContext>, ICommentRepository<CommentEntity>
    {
        public CommentRepository(ApplicationDBContext dBContext, IMapper mapper) : base(dBContext, mapper)
        {
        }

        public IQueryable<TComment> GetCommentByLessonId<TComment>(Guid lessonid) where TComment : IComment
        {
            return this.dBContext.Set<CommentEntity>()
                .Where(x=>x.LessonId == lessonid)
                .ProjectTo<TComment>(_mapper.ConfigurationProvider);
        }

      
    }
}
