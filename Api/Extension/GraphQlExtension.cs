using Api.Schemas.Mutation;
using Api.Schemas.Query;
using Domain.Errors;
using Domain.Errors.UnionError;
using Domain.Untils;
using HotChocolate.Execution.Configuration;
using HotChocolate.Types;
using HotChocolate.Utilities;
using Infrastructure.DB.SQLDbContext;
using System.Diagnostics;
using System.Reflection;

namespace Api.Extension
{
    public static class GraphQlExtension
    {
        public static IRequestExecutorBuilder AddGraphExtension(this IRequestExecutorBuilder builder)
        {
            var baseErrorType = typeof(BaseUnionError);


            var Errors = Assembly.Load("Domain").GetTypes()
                .Where(x => baseErrorType.IsAssignableFrom(x) && x.Name != baseErrorType.Name).ToArray();



            builder

                .RegisterDbContext<ApplicationDBContext>()
                .AddQueryType<Queries>()
                .AddMutationType<Mutations>()
                .AddTypeExtension<AccountMutation>()
                .AddTypes(Errors)
                .AddProjections()
                .AddFiltering()
                ;

           
            


            return builder;
        }
    }
}
