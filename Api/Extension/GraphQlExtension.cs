
using Api.Mutation;
using Api.Query;
using HotChocolate.Execution.Configuration;
using HotChocolate.Types;
using Infrastructure.DB.SQLDbContext;

namespace Api.Extension
{
    public static class GraphQlExtension
    {
        public static IRequestExecutorBuilder AddGraphExtension(this IRequestExecutorBuilder builder)
        {
            builder.AddQueryType<Queries>()
                .AddMutationType<Mutations>()
                .RegisterDbContext<ApplicationDBContext>()
                .AddProjections()
                .AddFiltering()
                .AddType(new UuidType())
                .AddTypeExtension<AccountQuery>()
                .AddTypeExtension<AccountMutation>()
                .AddTypeExtension<SeedData>();
                

            return builder;
        }
    }
}
