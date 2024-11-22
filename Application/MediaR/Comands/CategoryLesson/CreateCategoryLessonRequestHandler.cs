using AutoMapper;
using Domain.Entities;
using Domain.Types.ErrorTypes.Erros.Course;
using Domain.Types.ErrorTypes.Unions.CategoryLesson;
using Domain.Untils;
using Infrastructure.Unit0fWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.CategoryLesson
{
    public class CreateCategoryLessonRequestHandler : IRequestHandler<CreateCategoryLessonRequest, MutationPayload<CreateCategoryLessonRequest, CreateCategoryLessonError>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;
        public CreateCategoryLessonRequestHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<MutationPayload<CreateCategoryLessonRequest, CreateCategoryLessonError>> Handle(CreateCategoryLessonRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var errors = new List<CreateCategoryLessonError>();

                var authorId = _contextAccessor.GetId();

                var course = await _unitOfWork.courseRepository.FindOneAsync(request.CourseId);

                if(course is null || course.IsDeleted)
                {
                    errors.Add(new CourseNotFoundError());

                    return new MutationPayload<CreateCategoryLessonRequest, CreateCategoryLessonError>
                    {
                        errors = errors
                    };
                }


                if(course.AuthorId.Equals(authorId) is false)
                {
                    errors.Add(new UnAuthorError());

                    return new MutationPayload<CreateCategoryLessonRequest, CreateCategoryLessonError>
                    {
                        errors = errors
                    };
                }

                var categoryLesson = new CategoryLessonEntity
                {
                    Id = request.Id,
                    UserId=authorId,
                    CourseId = course.Id,
                    Name = request.Name,
                };

                await _unitOfWork.categoryLessonRepository.AddOneAsync(categoryLesson);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<CreateCategoryLessonRequest, CreateCategoryLessonError>
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
