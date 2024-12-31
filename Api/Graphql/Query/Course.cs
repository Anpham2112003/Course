using Api.DataLoader;
using Api.Middleware;
using Domain.DTOs;
using Domain.Schemas;
using Domain.Untils;
using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Data;
using HotChocolate.Types;
using Infrastructure.Unit0fWork;

namespace Api.Schemas.Query
{
    public class Course:ICourse
    {
      
        public Guid Id { get; set; }

        [GraphQLIgnore()]
        public Guid AuthorId { get; set; }
        public string? Name { get; set; }
        public float Price { get; set; }
        public bool IsSale { get; set; }
        public int Sale { get; set; }
        public DateTime Expired { get; set; }
        public string? Description { get; set; }
        public float Rating { get; set; }
        public float Duration { get; set; }
        public string? Thumbnail { get; set; }
        public bool IsPublish { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

       

        public async Task<PublicUser?> GetAuthor(GetPublicUserDataLoader loader,CancellationToken cancellation)
        {
            return  await loader.LoadAsync(AuthorId,cancellation);               
        }

        public async Task<int> TotalPurchase([Service(ServiceKind.Resolver)] IUnitOfWork unitOfWork, CancellationToken cancellation)
        {
            return await unitOfWork.purchaseRepository.GetTotalPurchaseByCourseId(Id,cancellation);
        }

        [UseOffsetPaging]
        [UseSorting]
        public IQueryable<CategoryLesson> GetCategoryLessons([Service(ServiceKind.Resolver)] IUnitOfWork unitOfWork)
        {
            return  unitOfWork.categoryLessonRepository.GetCategoryLessonByCourseId<CategoryLesson>(Id);
        }

        [UseOffsetPaging]
        [UseSorting]
        public IQueryable<FeedBack> GetFeedBacks([Service(ServiceKind.Resolver)] IUnitOfWork unitOfWork)
        {
            return  unitOfWork.feedbackRepository.GetFeedBackByCourseIds<FeedBack>(Id);
        }

        public async Task<IEnumerable<Tag>> GetTags([Service(ServiceKind.Resolver)] IUnitOfWork unitOfWork,CancellationToken cancellation)
        {
            return await unitOfWork.courseRepository.GetTagsByCourseId<Tag>(Id,cancellation);
        }
        
        public async Task<IEnumerable<Topic>> GetTopics([Service(ServiceKind.Resolver)] IUnitOfWork unitOfWork,CancellationToken cancellation)
        {
            return await unitOfWork.courseRepository.GetTopicsByCourseId<Topic>(Id,cancellation);
        }

        public async Task<AverageRate> AverageRate([Service(ServiceKind.Resolver)] IUnitOfWork unitOfWork,CancellationToken cancellation)
        {
            var result = await unitOfWork.feedbackRepository.TotalRate(Id,cancellation);

            if (result == null || result.TotalFeedback == 0)
            {
                return new AverageRate
                {
                    TotalFeedback = 0,
                    TotalRate = 5
                };
            }

            return result;
        }
        
        [Authorize]
        public async Task<bool> Purchased([Service(ServiceKind.Resolver)] IUnitOfWork unitOfWork, [Service] IHttpContextAccessor accessor, CancellationToken cancellation)
        {
            var userId = accessor.GetId();

            return await unitOfWork.purchaseRepository.CheckPurchased(userId,Id,cancellation);
        }


         
    }
}
