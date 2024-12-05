using Application.MediaR.Comands.CategoryLesson;
using Application.MediaR.Comands.Course;
using Application.MediaR.Comands.FeedBack;
using Application.MediaR.Comands.Lesson;
using Application.MediaR.Comands.Message;
using Application.MediaR.Comands.User;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Schemas;
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
                .AfterMap<CreateCourseAfterMap>();

            CreateMap<UpdateCourseRequest, CourseEntity>();

            CreateMap<CreateCategoryLessonRequest, CategoryLessonEntity>();

            CreateMap<CreateFeedbackRequest,FeedbackEntity>()
                .AfterMap<CreateFeedbackAfterMap>();

            CreateMap<CreateLessonRequest, LessonEntity>();

            CreateMap<CartEntity, OrderDTO>()
                .ForMember(x => x.Id, x => x.MapFrom(x => x.Id))
                .ForMember(x=>x.UserId,x=>x.MapFrom(x => x.UserId))
                .ForMember(x => x.Amount, x => x.MapFrom(x => x.courseEntity!.Price))
                .ForMember(x=>x.Name,x=>x.MapFrom(x=>x.courseEntity!.Name))
                .ForMember(x=>x.CourseId,x=>x.MapFrom(x=>x.CouresId))
                .ForMember(x=>x.Thumbnail,x=>x.MapFrom(x=>x.courseEntity!.Thumbnail))
                .AfterMap<CreateOrderAfterMap>();

            CreateMap<CreateMessageRequest, MessageEntity>();

            
            
        }
    }
}
