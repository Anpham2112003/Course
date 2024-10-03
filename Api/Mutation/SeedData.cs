using HotChocolate;
using HotChocolate.Types;
using Infrastructure.SeedData;
using Infrastructure.Services.UnitOfWorkService;

namespace Api.Mutation
{
    [ExtendObjectType(typeof(Mutations))]
    public class SeedData
    {
        public string SeedRole([Service] IUnitOfWork unitOfWork)
        {
            try
            {
                var seed = new Seed(unitOfWork.GetContext());

                seed.RunSeed();

                return "Ok";
            }
            catch (Exception)
            {
                return "False";
                throw;
            }
        }
    }
}
