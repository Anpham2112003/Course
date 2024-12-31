using Api.DataLoader;
using Api.Schemas.Query;
using Domain.Schemas;
using Domain.Types.EnumTypes;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;

namespace Api.Graphql.Query
{
    public class Comment : IComment
    {
      
        public Guid Id { get; set; }

        [GraphQLIgnore]
        public Guid UserId { get; set; }

        [GraphQLIgnore]
        public Guid LessonId { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public async Task<PublicUser?>GetUser(GetPublicUserDataLoader loader,CancellationToken cancellation)
        {
            return await loader.LoadAsync(UserId,cancellation);
        }


       
    }
}
