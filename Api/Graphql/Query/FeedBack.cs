using Api.DataLoader;
using Domain.Schemas;
using HotChocolate;

namespace Api.Schemas.Query;

public class FeedBack:IFeedback
{
 
    public Guid Id { get; set; }

    [GraphQLIgnore]
    public Guid UserId { get; set; }

    [GraphQLIgnore]
    public Guid CourseId { get; set; }
    public int Rate { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

   

    public async Task<PublicUser?> GetUser(GetPublicUserDataLoader loader)
    {
        return await loader.LoadAsync(UserId);
    }

    public async Task<Course?> GetCourse(GetCourseDataLoader loader)
    {
        return await loader.LoadAsync(CourseId);
    }
}