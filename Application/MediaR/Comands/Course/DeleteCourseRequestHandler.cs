
using Domain.Interfaces.Upload;
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
    public class DeleteCourseRequestHandler : IRequestHandler<DeleteCourseRequest, MutationPayload<Guid, DeleteCourseError>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloudinaryUploadService _uploadService;
        private readonly IHttpContextAccessor _contextAccessor;

        public DeleteCourseRequestHandler(IUnitOfWork unitOfWork, ICloudinaryUploadService uploadService, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _uploadService = uploadService;
            _contextAccessor = contextAccessor;
        }

        public async Task<MutationPayload<Guid, DeleteCourseError>> Handle(DeleteCourseRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var errors = new List<DeleteCourseError>();

                var authorId = _contextAccessor.GetId();
               

                var course = await _unitOfWork.courseRepository.FindOneAsync(request.Id);

                if (course is null || course.IsDeleted)
                {
                    errors.Add(new CourseNotFoundError());

                    return new MutationPayload<Guid, DeleteCourseError>
                    {
                        errors = errors
                    };
                }

                if(course.AuthorId.Equals(authorId) is false)
                {
                    errors.Add(new UnAuthorError());

                    return new MutationPayload<Guid, DeleteCourseError>
                    {
                        errors = errors
                    };
                }

                course.IsDeleted = true;

                _unitOfWork.courseRepository.UpdateOne(course);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<Guid, DeleteCourseError>
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
