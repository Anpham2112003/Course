using Domain.Entities;
using Domain.Types.EnumTypes;
using Domain.Types.ErrorTypes.Erros.CategoryLesson;
using Domain.Types.ErrorTypes.Erros.Comment;
using Domain.Types.ErrorTypes.Unions.Comment;
using Domain.Untils;
using Infrastructure.Unit0fWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Comment
{
    public class CreateCommentRequestHandler : IRequestHandler<CreateCommentRequest, MutationPayload<CreateCommentRequest, CreateCommentError>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IHttpContextAccessor _contextAccessor;

        public CreateCommentRequestHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
        }

        public async Task<MutationPayload<CreateCommentRequest, CreateCommentError>> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<CreateCommentError>();

            try
            {
                var userId = _contextAccessor.GetId();

                var categoryLesson = await _unitOfWork.categoryLessonRepository.FindOneAsync(request.LessonId);

                if (categoryLesson is null)
                {
                    errors.Add(new CategoryLessonNotFoundErorr());

                    return new MutationPayload<CreateCommentRequest, CreateCommentError>
                    {
                        errors = errors
                    };
                }

                var checkPurchased = await _unitOfWork.purchaseRepository.CheckPurchaseCourse(userId,categoryLesson.CourseId);
                
                if(!checkPurchased is false)
                {
                    errors.Add(new UnPermissionCommentError());

                    return new MutationPayload<CreateCommentRequest, CreateCommentError>
                    {
                        errors = errors
                    };
                }



                var comment = new CommentEntity
                {
                    Id = request.Id,
                    Content = request.Content,
                    LessonId = request.LessonId,
                    UserId = userId,
                };

                await  _unitOfWork.commentRepository.AddOneAsync(comment);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<CreateCommentRequest, CreateCommentError>
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
