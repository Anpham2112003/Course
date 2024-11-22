
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
    public class UpdateFeedbackRequestHandler : IRequestHandler<UpdateFeedbackRequest, MutationPayload<UpdateFeedbackRequest, UpdateFeedbackError>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;

        public UpdateFeedbackRequestHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
        }

        public async Task<MutationPayload<UpdateFeedbackRequest, UpdateFeedbackError>> Handle(UpdateFeedbackRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<UpdateFeedbackError>();

            try
            {
                var userId = _contextAccessor.GetId();

                var feedback = await _unitOfWork.feedbackRepository.FindOneAsync(request.Id);

                if(feedback is null)
                {
                    errors.Add(new FeedbackNotFoundError());

                    return new MutationPayload<UpdateFeedbackRequest, UpdateFeedbackError>
                    {
                        errors = errors
                    };
                }

                if (feedback.UserId.Equals(userId) is false)
                {
                    errors.Add(new UnPermssionFeedbackError());

                    return new MutationPayload<UpdateFeedbackRequest, UpdateFeedbackError> 
                    { 
                        errors = errors 
                    };
                };

                feedback.Content=request.Content;

                _unitOfWork.feedbackRepository.UpdateOne(feedback);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<UpdateFeedbackRequest, UpdateFeedbackError>
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
