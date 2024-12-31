using Api.Schemas.Mutation;
using Api.Schemas.Query;
using Domain.Untils;
using HotChocolate.Execution.Configuration;
using HotChocolate.Types;
using HotChocolate.Utilities;
using Infrastructure.DB.SQLDbContext;
using System.Diagnostics;
using System.Reflection;
using Application.MediaR.Comands.User;
using Domain.Types.ErrorTypes.Unions;
using Api.Graphql.Mutation;

namespace Api.Extensions
{
    public static class GraphQlExtension
    {
        public static IRequestExecutorBuilder AddGraphExtension(this IRequestExecutorBuilder builder)
        {
            var baseErrorType = typeof(BaseUnionError);


            var errors = Assembly.Load("Domain").GetTypes()
                .Where(x => baseErrorType.IsAssignableFrom(x) && x.Name != baseErrorType.Name).ToArray();
            
           


            builder

                .RegisterDbContext<ApplicationDBContext>()
                .AddQueryType<Queries>()
                .AddMutationType<Mutations>()
                .AddTypeExtension<AccountMutation>()
                .AddTypeExtension<UserMutation>()
                .AddTypeExtension<CategoryLessonMutation>()
                .AddTypeExtension<CourseMutation>()
                .AddTypeExtension<TagMutation>()
                .AddTypeExtension<FeedbackMutation>()
                .AddTypeExtension<LessonMutation>()
                .AddTypeExtension<CartMutation>()
                .AddTypeExtension<TopicMutation>()
                .AddTypeExtension<PermissionMutation>()
                .AddTypeExtension<PermissionMutation>()
                .AddType<UploadType>()
                .AddTypes(errors)
                .AddProjections()
                .AddFiltering();
                
            
            return builder;
        }
    }
}
