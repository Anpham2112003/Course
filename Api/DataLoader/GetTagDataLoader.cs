using Api.Schemas.Query;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using GreenDonut;
using HotChocolate.Data;
using Infrastructure.Unit0fWork;
using Microsoft.EntityFrameworkCore;

namespace Api.DataLoader
{
    public class GetTagDataLoader : BatchDataLoader<int, Tag>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetTagDataLoader(IBatchScheduler batchScheduler, IUnitOfWork unitOfWork, DataLoaderOptions? options = null, IMapper mapper = null) : base(batchScheduler, options)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        protected override async Task<IReadOnlyDictionary<int, Tag>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.tagRepository.GetTagByIds<Tag>(keys,cancellationToken);

            return result.ToDictionary(x => x.Id);
        }
    }
}
