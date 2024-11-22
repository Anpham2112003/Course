using Domain.Entities;
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
    public class AddTopicToCourseRequestHandler : IRequestHandler<AddTopicToCourseRequest, MutationPayload<AddTopicToCourseRequest, AddTopicToCourseError>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IHttpContextAccessor _contextAccessor;
        public AddTopicToCourseRequestHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
        }

        public async Task<MutationPayload<AddTopicToCourseRequest, AddTopicToCourseError>> Handle(AddTopicToCourseRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<AddTopicToCourseError>();

            try
            {
                var authorId = _contextAccessor.GetId();

                var check = await _unitOfWork.topicRepository.HasTopicCourse(request.TopicId,request.CourseId);

                if (check)
                {
                    errors.Add(new TopicCourseExistError());

                    return new MutationPayload<AddTopicToCourseRequest, AddTopicToCourseError>
                    {
                        errors = errors,
                    };
                }

                var topic = await _unitOfWork.tagRepository.FindOneAsync(request.TopicId);

                var course = await _unitOfWork.courseRepository.FindOneAsync(request.CourseId);

                if(topic is null ||  course is null || course.IsDeleted)
                {
                    errors.Add(new TopicOrCourseNotFoundError());

                    return new MutationPayload<AddTopicToCourseRequest, AddTopicToCourseError>
                    {
                        errors = errors
                    };
                }

                if( course.AuthorId.Equals(authorId) is false )
                {
                    errors.Add(new UnAuthorError());

                    return new MutationPayload<AddTopicToCourseRequest, AddTopicToCourseError>
                    {
                        errors = errors
                    };
                }

                var topicCourse = new CourseTopic
                {
                    TopicId = request.TopicId,
                    CourseId = course.Id,
                };

                await _unitOfWork.topicRepository.AddTopicCourse(topicCourse);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<AddTopicToCourseRequest, AddTopicToCourseError>
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
