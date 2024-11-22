using Api.Schemas.Query;
using GreenDonut;
using Infrastructure.Unit0fWork;

namespace Api.DataLoader
{
    public class GetPurchaseDataLoader : BatchDataLoader<Guid, Purchase>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPurchaseDataLoader(IBatchScheduler batchScheduler, IUnitOfWork unitOfWork, DataLoaderOptions? options = null ) : base(batchScheduler, options)
        {
            _unitOfWork = unitOfWork;
        }

        protected override async Task<IReadOnlyDictionary<Guid, Purchase>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.purchaseRepository.GetPurchaseByIds<Purchase>(keys, cancellationToken);

            return result.ToDictionary(x => x.Id);
        }
    }
}
