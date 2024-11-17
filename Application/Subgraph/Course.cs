using Domain.Interfaces.UnitOfWork;
using HotChocolate;

namespace Api.Schemas.Query;

public class Course
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public string? Name { get; set; }
    public int Purchase { get; set; }
    public float Price { get; set; }
    public bool IsSale {  get; set; }
    public int Sale {  get; set; }
    public DateTime Expired { get; set; }
    public string? Description { get; set; }
    public float Rating { get; set; }
    public float Duration { get; set; }
    public string? Thumbnail {  get; set; }
    public bool IsPublish {  get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public async Task<User?> GetAuthor([Service] IUnitOfWork unitOfWork)
    {
        return await unitOfWork.userRepository.GetUserByIdAsync(AuthorId);
    }
}