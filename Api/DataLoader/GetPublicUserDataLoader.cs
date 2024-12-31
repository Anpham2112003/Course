using Api.Schemas.Query;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.Schemas;
using GreenDonut;
using Infrastructure.Unit0fWork;
using Microsoft.EntityFrameworkCore;

namespace Api.DataLoader;

public class GetPublicUserDataLoader : BatchDataLoader<Guid, PublicUser>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetPublicUserDataLoader(IBatchScheduler batchScheduler, IUnitOfWork unitOfWork, DataLoaderOptions? options = null) : base(batchScheduler, options)
    {
        _unitOfWork = unitOfWork;
      
    }

    protected override async Task<IReadOnlyDictionary<Guid, PublicUser>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
    {
        var users =await _unitOfWork.userRepository.GetUserByIds<PublicUser>(keys,cancellationToken);

        return users.ToDictionary(x => x.id);
    }
}