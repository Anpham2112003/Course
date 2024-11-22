
using Domain.Types.ErrorTypes.Erros.CategoryLesson;
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
    public class UpdateCategoryLessonRequestHandler : IRequestHandler<UpdateCategoryLessonRequest, MutationPayload<UpdateCategoryLessonRequest, UpdateCategoryLessonError>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;

        public UpdateCategoryLessonRequestHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
        }

        public async Task<MutationPayload<UpdateCategoryLessonRequest, UpdateCategoryLessonError>> Handle(UpdateCategoryLessonRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<UpdateCategoryLessonError>();

            try
            {
                var authorId = _contextAccessor.GetId();

                var categoryLesson = await _unitOfWork.categoryLessonRepository.FindOneAsync(request.Id);

                if(categoryLesson is null || categoryLesson.IsDeleted)
                {
                    errors.Add(new CategoryLessonNotFoundErorr());

                    return new MutationPayload<UpdateCategoryLessonRequest, UpdateCategoryLessonError>
                    {
                        errors = errors
                    };
                }

                if(categoryLesson.UserId.Equals(authorId) is false)
                {
                    errors.Add(new UnAuthorError());

                    return new MutationPayload<UpdateCategoryLessonRequest, UpdateCategoryLessonError>
                    {
                        errors = errors
                    };
                }

                categoryLesson.Name= request.Name;

                _unitOfWork.categoryLessonRepository.UpdateOne(categoryLesson);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<UpdateCategoryLessonRequest, UpdateCategoryLessonError>
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
