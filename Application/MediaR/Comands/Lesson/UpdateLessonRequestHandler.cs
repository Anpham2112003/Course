using AutoMapper;
using Domain.Types.ErrorTypes.Erros.Course;
using Domain.Types.ErrorTypes.Erros.Lesson;
using Domain.Types.ErrorTypes.Unions.Lesson;
using Domain.Untils;
using Infrastructure.Unit0fWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Lesson
{
    public class UpdateLessonRequestHandler : IRequestHandler<UpdateLessonRequest, MutationPayload<UpdateLessonRequest, UpdateLessonError>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;
        public UpdateLessonRequestHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<MutationPayload<UpdateLessonRequest, UpdateLessonError>> Handle(UpdateLessonRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<UpdateLessonError>();

            try
            {
                var authorId = _contextAccessor.GetId();

                var lesson = await _unitOfWork.lessonRepository.FindOneAsync(request.Id);

                if(lesson is null  || lesson.IsDeleted)
                {
                    errors.Add(new LessonNotFoundError());

                    return new MutationPayload<UpdateLessonRequest, UpdateLessonError>
                    {
                        errors = errors
                    };
                };

                if(lesson.UserId.Equals(_contextAccessor.GetId()) is false)
                {
                    errors.Add(new UnAuthorError());

                    return new MutationPayload<UpdateLessonRequest, UpdateLessonError>
                    {
                        errors = errors
                    };
                }

                var course = await _unitOfWork.courseRepository.FindOneAsync(lesson.CourseId);

                if(course is not null)
                {
                    course.Duration=  (course.Duration-lesson.Duration) + request.Duration;

                    _unitOfWork.courseRepository.UpdateOne(course);
                }

                _mapper.Map(request, lesson);

                _unitOfWork.lessonRepository.UpdateOne(lesson);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<UpdateLessonRequest, UpdateLessonError>
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
