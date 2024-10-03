using ApplicationCore.Interfaces.RepositoryBase;
using Domain.Entities;
using Infrastructure.DB.SQLDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.RepositoryService
{
    public class UserRepository : AbstractRepository<UserEntity, ApplicationDBContext>, IUserRepository<UserEntity>
    {
        public UserRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
