using Api.Graphql.Query;
using Api.Schemas.Query;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Schemas;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace Api.Projection
{
    public class MapperProjection : Profile
    {
        public MapperProjection()
        {
            

            CreateProjection<CartEntity, Cart>();

            CreateProjection<CategoryLessonEntity, CategoryLesson>();

            CreateProjection<CourseEntity, Course>();

            CreateProjection<FeedbackEntity, FeedBack>();

            CreateProjection<LessonEntity, PrivateLesson>();

            CreateProjection<LessonEntity,PublicLesson>();

            CreateProjection<PurchaseEntity, Purchase>();

            CreateProjection<TagEntity, Schemas.Query.Tag>();

            CreateProjection<TopicEntity, Topic>();

            CreateProjection<UserEntity, PrivateUser>();

            CreateProjection<UserEntity, PublicUser>();

            CreateMap<PaymentEntity, Payment>();

        }

    }
}
