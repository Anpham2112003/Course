
using Domain.Types.ErrorTypes.Erros.Course;
using Domain.Types.ErrorTypes.Unions.Course;
using Domain.Untils;
using Infrastructure.Unit0fWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Course
{
    public class PublishCourseRequestHandler : IRequestHandler<PublishCourseRequest, MutationPayload<Guid, PublishCourseError>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;

        public PublishCourseRequestHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
        }

        public async Task<MutationPayload<Guid, PublishCourseError>> Handle(PublishCourseRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<PublishCourseError>();
            
            try
            {
                var authorId = _contextAccessor.GetId();

                var course = await _unitOfWork.courseRepository.FindOneAsync(request.Id);

                if(course is null || course.IsDeleted == true)
                {
                    errors.Add(new CourseNotFoundError());

                    return new MutationPayload<Guid, PublishCourseError>
                    {
                        errors = errors
                    };
                }

                if(course.AuthorId.Equals(_contextAccessor.GetId()) is false)
                {
                    errors.Add(new UnAuthorError());

                    return new MutationPayload<Guid, PublishCourseError>
                    {
                        errors = errors
                    };
                }

                if (course.IsPublish)
                {
                    errors.Add(new PublishedError());

                    return new MutationPayload<Guid, PublishCourseError>
                    {
                        errors = errors
                    };
                }

                course.IsPublish=true;

                _unitOfWork.courseRepository.UpdateOne(course);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<Guid, PublishCourseError>
                {
                    payload = request.Id,
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
