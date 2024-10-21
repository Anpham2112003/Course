using Domain.Interfaces.UnitOfWork;
using Domain.Interfaces.Upload;
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
    public class UpdateThumbnailCourseRequestHandler : IRequestHandler<UpdateThumbnailCourseRequest, MutationPayload<string, UpdateThumbnailCourseError>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICloudinaryUploadService _uploadService;

        private readonly IHttpContextAccessor _contextAccessor;

        public UpdateThumbnailCourseRequestHandler(IUnitOfWork unitOfWork, ICloudinaryUploadService uploadService, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _uploadService = uploadService;
            _contextAccessor = contextAccessor;
        }

        public async Task<MutationPayload<string, UpdateThumbnailCourseError>> Handle(UpdateThumbnailCourseRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var errors = new List<UpdateThumbnailCourseError>();

                var author = await _unitOfWork.userRepository.FindUserByAccountIdAsync(_contextAccessor.GetId());

                if(author is null || author.IsDeleted)
                {
                    errors.Add(new AuthorNotFoundError());

                    return new MutationPayload<string, UpdateThumbnailCourseError>
                    {
                        errors = errors,
                    };
                }

                var course = await _unitOfWork.courseRepository.FindOneAsync(request.Id);

                if (course is null || course.IsDeleted)
                {
                    errors.Add(new CourseNotFoundError());

                    return new MutationPayload<string, UpdateThumbnailCourseError>
                    {
                        errors = errors,
                    };
                }

                if(course.UserId.Equals(author.Id) is false)
                {
                    errors.Add(new NotAuthorError());

                    return new MutationPayload<string, UpdateThumbnailCourseError>
                    {
                        errors = errors,
                    };
                }

                if (string.IsNullOrEmpty(course.Thumbnail))
                {
                    var thumbnailId = course.Thumbnail!.Split('/').Last().Split('.').First();

                    var delete = _uploadService.DeleteImageByPublicId(thumbnailId);
                }

                var upload = await _uploadService.UploadImageAsync(request.File!,cancellationToken);

                if(upload.StatusCode!=System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Upload image fail!");
                }

                course.Thumbnail=upload.Url.ToString();

                _unitOfWork.courseRepository.UpdateOne(course);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<string, UpdateThumbnailCourseError>
                {
                    payload = upload.Url.ToString(),
                };

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
