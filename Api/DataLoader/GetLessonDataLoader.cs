using Api.Schemas.Query;
using GreenDonut;
using Infrastructure.Unit0fWork;

namespace Api.DataLoader
{
    public class GetLessonDataLoader : BatchDataLoader<Guid, PrivateLesson>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetLessonDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions? options = null, IUnitOfWork unitOfWork = null) : base(batchScheduler, options)
        {
            _unitOfWork = unitOfWork;
        }

        protected override async Task<IReadOnlyDictionary<Guid, PrivateLesson>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.lessonRepository.GetLessonByIds<PrivateLesson>(keys, cancellationToken);

            return result.ToDictionary(x => x.Id);
        }
    }
}
