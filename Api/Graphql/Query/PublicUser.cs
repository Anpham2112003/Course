using Api.DataLoader;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.Schemas;
using GreenDonut;
using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Data;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Infrastructure.Unit0fWork;

namespace Api.Schemas.Query
{
    public class PublicUser : IUser
    {
      
        public Guid id { get; set; }
        public string? FullName { get; set; }
        public bool Gender { get; set; }
        public string? Avatar { get; set; }
        public bool IsLecturer { get; set; }
        public string? Information { get; set; }


      


        [UseOffsetPaging]
        [UseSorting]
        public  IQueryable<Course> GetCourses([Service(ServiceKind.Resolver)]IUnitOfWork unitOfWork)
        {
            return  unitOfWork.courseRepository.GetCoursesByUserId<Course>(id);
        }



    }
}
