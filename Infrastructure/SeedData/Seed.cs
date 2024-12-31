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

        public void SeedPermission()
        {
            if(_dbContext.Set<PermissionEntity>().Any() is false)
            {
                _dbContext.Set<PermissionEntity>().AddRange(PermissionData.permissions);

               _dbContext.SaveChanges();
            }
        }

        public void SeedTag()
        {
           var result = _dbContext.Set<TagEntity>().Any();
            if (!result)
            {
                
                _dbContext.Set<TagEntity>().AddRange(TagData.tags);

                _dbContext.SaveChanges();
            }
        }
    }
    
}
