using Domain.Entities;
using Domain.Interfaces.RepositoryBase;
using Infrastructure.DB.SQLDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.RepositoryService
{
    public class CourseRepository : AbstractRepository<CourseEntity, ApplicationDBContext>, ICourseRepository<CourseEntity>
    {
        public CourseRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
