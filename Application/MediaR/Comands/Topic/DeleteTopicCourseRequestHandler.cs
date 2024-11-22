using Domain.Types.ErrorTypes.Erros.Course;
using Domain.Types.ErrorTypes.Erros.Topic;
using Domain.Types.ErrorTypes.Unions.Topic;
using Domain.Untils;
using Infrastructure.Unit0fWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Topic
{
    public class DeleteTopicCourseRequestHandler : IRequestHandler<DeleteTopicCourseRequest, MutationPayload<DeleteTopicCourseRequest, DeleteTopicCourseError>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;

        public DeleteTopicCourseRequestHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
        }

        public async Task<MutationPayload<DeleteTopicCourseRequest, DeleteTopicCourseError>> Handle(DeleteTopicCourseRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<DeleteTopicCourseError>();

            try
            {
                var authorId = _contextAccessor.GetId();

                var topicCourse = await _unitOfWork.topicRepository.FindTopicCourse(request.TopicId, request.CourseId);

                if(topicCourse is null)
                {
                    errors.Add(new TopicCourseNotFoundError());

                    return new MutationPayload<DeleteTopicCourseRequest, DeleteTopicCourseError>
                    {
                        errors = errors,
                    };
                }

                var course = await _unitOfWork.courseRepository.FindOneAsync(request.CourseId);

                if(course is null || course.AuthorId.Equals(authorId) is false)
                {
                    errors.Add(new UnAuthorError());

                    return new MutationPayload<DeleteTopicCourseRequest, DeleteTopicCourseError>
                    {
                        errors = errors,
                    };
                }

                _unitOfWork.topicRepository.DeleteTopicCourse(topicCourse);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<DeleteTopicCourseRequest, DeleteTopicCourseError>
                {
                    payload = request,
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
