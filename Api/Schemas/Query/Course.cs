using Api.DataLoader;
using Domain.Schemas;
using HotChocolate;
using HotChocolate.ApolloFederation;
using Infrastructure.Unit0fWork;

namespace Api.Schemas.Query
{
    public class Course:ICourse
    {
        [Key]
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string? Name { get; set; }
        public int Purchase { get; set; }
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

        [ReferenceResolver]
        public static async Task<Course?> GetCourse(Guid Id, GetCourseDataLoader loader)
        {
            return await loader.LoadAsync(Id);
        }

        public async Task<User?> GetAuthor(GetUserDataLoader loader)
        {
            return  await loader.LoadAsync(AuthorId);
        }

        public async Task

        public async Task<IEnumerable<FeedBack>> GetFeedBacks(int skip,int limit,[Service(ServiceKind.Resolver)] IUnitOfWork unitOfWork,CancellationToken token)
        {
            return await unitOfWork.feedbackRepository.GetFeedBackByCourseIds<FeedBack>(Id,skip,limit,token);
        }

        public async Task<IEnumerable<Tag>> GetTags([Service(ServiceKind.Resolver)] IUnitOfWork unitOfWork,CancellationToken cancellation)
        {
            return await unitOfWork.courseRepository.GetTagsByCourseId<Tag>(Id,cancellation);
        }
        
        public async Task<IEnumerable<Topic>> GetTopics([Service] IUnitOfWork unitOfWork,CancellationToken cancellation)
        {
            return await unitOfWork.courseRepository.GetTopicsByCourseId<Topic>(Id,cancellation);
        }
         
    }
}
