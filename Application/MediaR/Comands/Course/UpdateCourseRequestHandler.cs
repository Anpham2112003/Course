using AutoMapper;
using Domain.Entities;
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
    public class UpdateCourseRequestHandler : IRequestHandler<UpdateCourseRequest, MutationPayload<UpdateCourseRequest, UpdateCourseError>>
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

        public async Task<MutationPayload<UpdateCourseRequest, UpdateCourseError>> Handle(UpdateCourseRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var errors = new List<UpdateCourseError>();

                var authorId = _contextAccessor.GetId();

                var course = await _unitOfWork.courseRepository.FindOneAsync(request.Id);

                if(course is null || course.IsDeleted)
                {
                    errors.Add(new CourseNotFoundError());

                    return new MutationPayload<UpdateCourseRequest, UpdateCourseError>
                    {
                        errors = errors
                    };
                }

                if(course.AuthorId.Equals(authorId) is false)
                {
                    errors.Add(new UnAuthorError());

                    return new MutationPayload<UpdateCourseRequest, UpdateCourseError>
                    {
                        errors = errors
                    };
                }

                _mapper.Map(request, course);

                _unitOfWork.courseRepository.UpdateOne(course);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<UpdateCourseRequest, UpdateCourseError>
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
