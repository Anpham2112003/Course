using Application.MediaR.Comands.Course;
using Application.MediaR.Comands.User;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Maper
{
    public class MapData : Profile
    {
        public MapData()
        {
            CreateMap<UpdateProfileUserRequest, UserEntity>();

            CreateMap<CreateCourseRequest, CourseEntity>()
                
                .ForSourceMember(x => x.File, op => op.DoNotValidate())
                .BeforeMap<CreateCourseBeforeMap>();

            CreateMap<UpdateCourseRequest, CourseEntity>();
        }
    }
}
