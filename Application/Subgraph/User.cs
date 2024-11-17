namespace Api.Schemas.Query;

public class User
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName { get; set; }
    public bool Gender {  get; set; }
    public string? Avatar { get; set; }
    public bool IsLecturer { get; set; }
    public string? Information {  get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DeletedAt { get; set; }
}