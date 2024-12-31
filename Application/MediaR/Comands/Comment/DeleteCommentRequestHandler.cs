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
    public class DeleteCommentRequestHandler : IRequestHandler<DeleteCommentRequest, MutationPayload<DeleteCommentRequest, DeleteCommentError>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;

        public DeleteCommentRequestHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
        }

        public async Task<MutationPayload<DeleteCommentRequest, DeleteCommentError>> Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<DeleteCommentError>();

            try
            {
                var userId = _contextAccessor.GetId();

                var comment = await _unitOfWork.commentRepository.FindOneAsync(request.Id);
                
                if(comment is null)
                {
                    errors.Add(new CommentNotFoundError());

                    return new MutationPayload<DeleteCommentRequest, DeleteCommentError>
                    {
                        errors = errors
                    };
                }

                if(comment.UserId.Equals(userId) is false)
                {
                    errors.Add(new UnPermissionCommentError());

                    return new MutationPayload<DeleteCommentRequest, DeleteCommentError>
                    {
                        errors = errors
                    };
                }

                comment.IsDeleted = true;

                _unitOfWork.commentRepository.UpdateOne(comment);
                
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<DeleteCommentRequest, DeleteCommentError>
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
