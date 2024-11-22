
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
    public class DeleteCategoryLessonRequestHandler : IRequestHandler<DeleteCategoryLessonRequest, MutationPayload<Guid, DeleteCategoryLessonError>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;

        public DeleteCategoryLessonRequestHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
        }

        public async Task<MutationPayload<Guid, DeleteCategoryLessonError>> Handle(DeleteCategoryLessonRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var errors = new List<DeleteCategoryLessonError>();

                var authorId = _contextAccessor.GetId();

                var categoryLesson = await _unitOfWork.categoryLessonRepository.FindOneAsync(request.Id);

                if(categoryLesson is null || categoryLesson.IsDeleted)
                {
                    errors.Add(new CategoryLessonNotFoundErorr());

                    return new MutationPayload<Guid, DeleteCategoryLessonError>
                    {
                        errors = errors
                    };
                }

                if(categoryLesson.UserId.Equals(_contextAccessor.GetId()) is false)
                {
                    errors.Add(new UnAuthorError());

                    return new MutationPayload<Guid, DeleteCategoryLessonError>
                    {
                        errors = errors
                    };
                }

                categoryLesson.IsDeleted=true;

                _unitOfWork.categoryLessonRepository.UpdateOne(categoryLesson);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<Guid, DeleteCategoryLessonError>
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
