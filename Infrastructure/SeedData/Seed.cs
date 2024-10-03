using Domain.Entities;
using Infrastructure.DB.SQLDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SeedData
{
    public sealed class Seed
    {
        
        
        private readonly ApplicationDBContext _dbContext;



        public Seed(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public   void RunSeed()
        {
            if (!_dbContext.Roles.Any())
            {
                _dbContext.Roles.AddRange(RolesData.roleEntities);

                _dbContext.SaveChanges();
                
            }
            
        }
    }
    
}
