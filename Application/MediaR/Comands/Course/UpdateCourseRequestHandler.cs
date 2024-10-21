using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Types.ErrorTypes.BaseError.CourseUnion;
using Domain.Types.ErrorTypes.ErrorImplement.CourseErros;
using Domain.Untils;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Course
{
    public class UpdateCourseRequestHandler : IRequestHandler<UpdateCourseRequest, MutationPayload<CourseEntity, UpdateCourseError>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public UpdateCourseRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        public async Task<MutationPayload<CourseEntity, UpdateCourseError>> Handle(UpdateCourseRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var errors = new List<UpdateCourseError>();      

                var author = await _unitOfWork.userRepository.FindUserByAccountIdAsync(_contextAccessor.GetId());

                if (author is null || author.IsDeleted)
                {
                    errors.Add(new AuthorNotFoundError());

                    return new MutationPayload<CourseEntity, UpdateCourseError>
                    {
                        errors = errors
                    };
                }

                var course = await _unitOfWork.courseRepository.FindOneAsync(request.Id);

                if(course is null || course.IsDeleted)
                {
                    errors.Add(new CourseNotFoundError());

                    return new MutationPayload<CourseEntity, UpdateCourseError>
                    {
                        errors = errors
                    };
                }

                if(course.UserId.Equals(author.Id) is false)
                {
                    errors.Add(new NotAuthorError());

                    return new MutationPayload<CourseEntity, UpdateCourseError>
                    {
                        errors = errors
                    };
                }

                _mapper.Map(request, course);

                _unitOfWork.courseRepository.UpdateOne(course);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<CourseEntity, UpdateCourseError>
                {
                    payload = course,
                };



            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
