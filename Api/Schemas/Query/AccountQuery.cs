using HotChocolate.Types;

namespace Api.Schemas.Query
{
    [ExtendObjectType(typeof(Queries))]
    public static class AccountQuery
    {
        public static string Hello() => "Hello";
    }
}
