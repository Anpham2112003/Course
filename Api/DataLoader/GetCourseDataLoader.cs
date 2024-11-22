using Api.Schemas.Query;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using GreenDonut;
using Infrastructure.Unit0fWork;
using Microsoft.EntityFrameworkCore;

namespace Api.DataLoader;

public class GetCourseDataLoader : BatchDataLoader<Guid, Course>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetCourseDataLoader(IBatchScheduler batchScheduler, IUnitOfWork unitOfWork, DataLoaderOptions? options = null) : base(batchScheduler, options)
    {
        _unitOfWork = unitOfWork;
    }

    protected override async Task<IReadOnlyDictionary<Guid, Course>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
    {
        var course = await _unitOfWork.courseRepository.GetCourseByIds<Course>(keys,cancellationToken);

        return course.ToDictionary(x => x.Id);
    }
}