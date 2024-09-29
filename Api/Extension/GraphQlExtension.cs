
using Api.Mutation;
using Api.Query;
using HotChocolate.Execution.Configuration;
using HotChocolate.Types;

namespace Api.Extension
{
    public static class GraphQlExtension
    {
        public static IRequestExecutorBuilder AddGraphExtension(this IRequestExecutorBuilder builder)
        {
            builder.AddQueryType<Queries>()
                .AddMutationType<Mutations>()
                .AddTypeExtension<AccountQuery>()
                .AddTypeExtension<AccountMutation>();
                

            return builder;
        }
    }
}
