using HotChocolate.Types;

namespace Api.Query
{
    [ExtendObjectType(typeof(Queries))]
    public  class AccountQuery
    {
        public  string Hello() => "Hello";
    }
}
