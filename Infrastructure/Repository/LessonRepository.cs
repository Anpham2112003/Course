using Domain.Entities;
using Infrastructure.DB.SQLDbContext;
using Infrastructure.Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class LessonRepository : AbstractRepository<LessonEntity, ApplicationDBContext>, ILessonRepository<LessonEntity>
    {
        public LessonRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
