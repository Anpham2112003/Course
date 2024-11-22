using Api.Schemas.Query;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.Schemas;
using GreenDonut;
using Infrastructure.Unit0fWork;
using Microsoft.EntityFrameworkCore;

namespace Api.DataLoader;

public class GetUserDataLoader : BatchDataLoader<Guid, User>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetUserDataLoader(IBatchScheduler batchScheduler, IUnitOfWork unitOfWork, DataLoaderOptions? options = null, IMapper mapper = null) : base(batchScheduler, options)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    protected override async Task<IReadOnlyDictionary<Guid, User>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
    {
        var users =await _unitOfWork.userRepository.GetUserByIds<User>(keys,cancellationToken);

        return users.ToDictionary(x => x.id);
    }
}