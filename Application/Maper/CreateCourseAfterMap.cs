using Application.MediaR.Comands.Course;
using AutoMapper;
using Domain.Entities;
using Domain.Untils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Maper
{
    public class CreateCourseAfterMap : IMappingAction<CreateCourseRequest, CourseEntity>
    {
       private readonly IHttpContextAccessor _contextAccessor;

        public CreateCourseAfterMap(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void Process(CreateCourseRequest source, CourseEntity destination, ResolutionContext context)
        {

            destination.AuthorId = _contextAccessor.GetId();

            destination.Duration = 0;

            destination.IsSale = false;

            destination.Rating = 5;

            destination.CreatedAt = DateTime.UtcNow;

            

        }
    }
}
