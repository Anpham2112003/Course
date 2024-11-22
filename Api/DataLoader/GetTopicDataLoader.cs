using Api.Schemas.Query;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using GreenDonut;
using Infrastructure.Unit0fWork;
using Microsoft.EntityFrameworkCore;

namespace Api.DataLoader
{
    public class GetTopicDataLoader : BatchDataLoader<int, Topic>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetTopicDataLoader(IBatchScheduler batchScheduler, IUnitOfWork unitOfWork, DataLoaderOptions? options = null, IMapper mapper = null) : base(batchScheduler, options)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        protected override async Task<IReadOnlyDictionary<int, Topic>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.topicRepository.GetTopicByIds<Topic>(keys,cancellationToken);

            return result.ToDictionary(x => x.Id);
        }
    }
}
