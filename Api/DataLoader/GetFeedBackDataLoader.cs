using Api.Schemas.Query;
using GreenDonut;
using Infrastructure.Unit0fWork;

namespace Api.DataLoader;

public class GetFeedBackDataLoader:BatchDataLoader<Guid, FeedBack>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public GetFeedBackDataLoader(IBatchScheduler batchScheduler, IUnitOfWork unitOfWork, DataLoaderOptions? options = null) : base(batchScheduler, options)
    {
        _unitOfWork = unitOfWork;
    }

    protected override async Task<IReadOnlyDictionary<Guid, FeedBack>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.feedbackRepository.GetFeedBackByIds<FeedBack>(keys, cancellationToken);
        
        return result.ToDictionary(x=>x.Id);
    }
}