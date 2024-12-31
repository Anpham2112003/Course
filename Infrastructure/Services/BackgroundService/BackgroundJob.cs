using Infrastructure.DB.SQLDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.Services.BackgroundService
{
    public class BackgroundJob:IBackgroundJob
    {
        private readonly ApplicationDBContext _dbContext;
       
        public BackgroundJob(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddTagNewToCourse()
        {
            var courseTag = await _dbContext.Set<CourseTag>()
                .Where(x => x.TagId == 1)
                .ToListAsync();

            _dbContext.RemoveRange(courseTag);

            await _dbContext.SaveChangesAsync();

            var coursesNew = await _dbContext.Set<CourseEntity>()
                .Where(x=>EF.Functions.DateDiffDay(x.CreatedAt, DateTime.Now) <3)
                .ToListAsync();

            foreach (var course in coursesNew)
            {
                course.courseTags.Add(new CourseTag
                {
                    CourseId = course.Id,
                    TagId = 1
                });
            }

            _dbContext.Set<CourseEntity>()
                .UpdateRange(coursesNew);

            await _dbContext.SaveChangesAsync();

            
        }

        public async Task AddTagBestSellToCourse()
        {
            var courseTag = await _dbContext.Set<CourseTag>().Where(x=>x.TagId==2).ToListAsync();

            _dbContext.RemoveRange(courseTag);

            await _dbContext.SaveChangesAsync();


            var courses = await _dbContext.Set<CourseEntity>()
                .Where(x=>x.IsSale==true&& x.IsDeleted==false)
                .OrderByDescending(x=>x.Sale)
                .Take(20)
                .ToListAsync();

            foreach (var course in courses)
            {
                course.courseTags.Add(new CourseTag
                {
                    CourseId = course.Id,
                    TagId = 2
                });
            }

            _dbContext.Set<CourseEntity>().UpdateRange(courses);

            await _dbContext.SaveChangesAsync();
        }


       

        
    }
}
