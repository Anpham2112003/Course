
using Domain.Types.ErrorTypes.Erros.Feedback;
using Domain.Types.ErrorTypes.Unions.Feedback;
using Domain.Untils;
using Infrastructure.Unit0fWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.FeedBack
{
    public class DeleteFeedbackRequestHandler : IRequestHandler<DeleteFeedbackRequest, MutationPayload<DeleteFeedbackRequest, DeleteFeedbackError>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;

        public DeleteFeedbackRequestHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
        }

        public async Task<MutationPayload<DeleteFeedbackRequest, DeleteFeedbackError>> Handle(DeleteFeedbackRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<DeleteFeedbackError>(); 

            try
            {
                var userId = _contextAccessor.GetId();

                var feedback = await _unitOfWork.feedbackRepository.FindOneAsync(request.Id);

                if(feedback is null)
                {
                    errors.Add(new FeedbackNotFoundError());

                    return new MutationPayload<DeleteFeedbackRequest, DeleteFeedbackError>
                    {
                        errors = errors
                    };
                }

                feedback.IsDeleted = true;

                _unitOfWork.feedbackRepository.UpdateOne(feedback);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<DeleteFeedbackRequest, DeleteFeedbackError>
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
