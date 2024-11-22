using Api.DataLoader;
using Domain.Schemas;
using HotChocolate.ApolloFederation;

namespace Api.Schemas.Query;

public class FeedBack:IFeedback
{
    [Key]
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CourseId { get; set; }
    public int Rate { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public static async Task<FeedBack?> GetFeedBack(Guid Id, GetFeedBackDataLoader loader)
    {
        return await loader.LoadAsync(Id);
    }

    public async Task<IUser> GetUser(GetUserDataLoader loader)
    {
        return await loader.LoadAsync(UserId);
    }

    public async Task<Course> GetCourse(GetCourseDataLoader loader)
    {
        return await loader.LoadAsync(CourseId);
    }
}