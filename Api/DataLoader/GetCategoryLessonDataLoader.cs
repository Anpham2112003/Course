using Api.Schemas.Query;
using GreenDonut;
using Infrastructure.Unit0fWork;

namespace Api.DataLoader
{
    public class GetCategoryLessonDataLoader : BatchDataLoader<Guid, CategoryLesson>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCategoryLessonDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions? options = null, IUnitOfWork unitOfWork = null) : base(batchScheduler, options)
        {
            _unitOfWork = unitOfWork;
        }

        protected override async Task<IReadOnlyDictionary<Guid, CategoryLesson>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.categoryLessonRepository.GetCategoryLessonByIds<CategoryLesson>(keys,cancellationToken);

            return result.ToDictionary(x=>x.Id);
        }
    }
}
