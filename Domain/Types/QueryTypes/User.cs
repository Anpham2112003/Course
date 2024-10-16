namespace Domain.Types.QueryTypes;

public class User
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName { get; set; }
    public bool Gender { get; set; }
    public string? Avatar { get; set; }
    public bool IsLecturer { get; set; }
    public string? Information { get; set; }
    public DateTime UpdatedAt { get; set; }

}