﻿using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Upload;
using Domain.Types.ErrorTypes.Erros.CategoryLesson;
using Domain.Types.ErrorTypes.Erros.Course;
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
    public class CreateLessonRequestHandler : IRequestHandler<CreateLessonRequest, MutationPayload<CreateLessonRequest, CreateLessonError>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public CreateLessonRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        public async Task<MutationPayload<CreateLessonRequest, CreateLessonError>> Handle(CreateLessonRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<CreateLessonError>();
            
            try
            {

                var categoryLesson = await _unitOfWork.categoryLessonRepository.FindOneAsync(request.CategoryLessonId);



                if(categoryLesson is null)
                {
                    errors.Add(new CategoryLessonNotFoundErorr());

                    return new MutationPayload<CreateLessonRequest, CreateLessonError>
                    {
                        errors = errors
                    };
                }

                if(categoryLesson.UserId.Equals(_contextAccessor.GetId()) is false)
                {
                    errors.Add(new UnAuthorError());

                    return new MutationPayload<CreateLessonRequest, CreateLessonError>
                    {
                        errors = errors
                    };
                }
                

                var lesson = _mapper.Map<LessonEntity>(request);

                lesson.CourseId=categoryLesson.CourseId;

                lesson.UserId=categoryLesson.UserId;

                var course = await _unitOfWork.courseRepository.FindOneAsync(categoryLesson.CourseId);

                if(course is not null)
                {
                    course.Duration = course.Duration + request.Duration / 60;

                    _unitOfWork.courseRepository.UpdateOne(course);
                }

                await _unitOfWork.lessonRepository.AddOneAsync(lesson);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<CreateLessonRequest, CreateLessonError>
                {
                    payload = request
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
