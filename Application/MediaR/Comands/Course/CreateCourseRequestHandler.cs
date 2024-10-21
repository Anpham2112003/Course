using AutoMapper;
using Domain.Entities;
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
    public class CreateCourseRequestHandler : IRequestHandler<CreateCourseRequest, MutationPayload<CourseEntity, CreateCourseError>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloudinaryUploadService _cloudinaryUploadService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public CreateCourseRequestHandler(IUnitOfWork unitOfWork, ICloudinaryUploadService cloudinaryUploadService, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _cloudinaryUploadService = cloudinaryUploadService;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        public async Task<MutationPayload<CourseEntity, CreateCourseError>> Handle(CreateCourseRequest request, CancellationToken cancellationToken)
        {
            var trans = await _unitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                var errors = new List<CreateCourseError>();
           
                var author = await _unitOfWork.userRepository.FindUserByAccountIdAsync(_contextAccessor.GetId());

                if(author is null || author.IsDeleted)
                {
                    errors.Add(new AuthorNotFoundError());

                    return new MutationPayload<CourseEntity, CreateCourseError>
                    {
                        errors = errors,
                    };
                }

                

                var course = _mapper.Map<CreateCourseRequest,CourseEntity>(request);

                var upload = await _cloudinaryUploadService.UploadImageAsync(request.File!, cancellationToken);

                if (upload.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Upload image fail!");
                }

                course.UserId=author.Id;

                course.Thumbnail = upload.Url.ToString();

                await _unitOfWork.courseRepository.AddOneAsync(course);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                await trans.CommitAsync(cancellationToken);

                return new MutationPayload<CourseEntity, CreateCourseError>
                {
                    payload = course,
                };
            }
            catch (Exception)
            {
                await trans.RollbackAsync();

                throw;
            }
        }
    }
}
