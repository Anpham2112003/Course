using Api.DataLoader;
using Api.Schemas.Query;
using Domain.Schemas;
using Domain.Types.EnumTypes;
using GreenDonut;

namespace Api.Graphql.Query;

public class Payment:IPayment
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public float Amount { get; set; }
    public string? BankTransactionId {  get; set; }
    public EnumPaymentMethod PaymentMethod { get; set; }
    public DateTime CreatedAt { get; set; }

    public async Task<Course> GetCourse(GetCourseDataLoader loader,CancellationToken cancellationToken )
    {
        return await loader.LoadAsync(CourseId,cancellationToken);
    }
}