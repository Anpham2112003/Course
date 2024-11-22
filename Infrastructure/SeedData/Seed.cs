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

        public   async void RunSeed()
        {
            if (!_dbContext.Roles.Any())
            {
                _dbContext.Roles.AddRange(RolesData.roleEntities);

                _dbContext.SaveChanges();
                
            }


            var convsertions = new List<ConversationEntity>()
            {
                new ConversationEntity
                {
                    Id=Guid.Parse("4727A548-683A-48BF-9E44-DF357FE68675"),
                    IsDeleted=false,
                    CreatedAt=DateTime.Now,
                    DeletedAt=DateTime.Now,
                    
                },

                new ConversationEntity
                {
                    Id=Guid.Parse("4727A548-683A-48BF-9E44-DF357FE68674"),
                    IsDeleted=false,
                    CreatedAt=DateTime.Now,
                    DeletedAt=DateTime.Now,

                }
            };

            if (!_dbContext.Conversations.Any())
            {
                _dbContext.AddRange(convsertions);

                _dbContext.SaveChanges();
            }
            
        }
    }
    
}
