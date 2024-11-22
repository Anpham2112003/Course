using AutoMapper;
using Domain.Entities;
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
    public class CreateFeedbackRequestHandler : IRequestHandler<CreateFeedbackRequest, MutationPayload<CreateFeedbackRequest, CreateFeedbackError>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IHttpContextAccessor _contextAccessor;

        private IMapper _mapper;

        public CreateFeedbackRequestHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<MutationPayload<CreateFeedbackRequest, CreateFeedbackError>> Handle(CreateFeedbackRequest request, CancellationToken cancellationToken)
        {
            var trans = await _unitOfWork.BeginTransactionAsync(cancellationToken);

            var errors = new List<CreateFeedbackError>();

            try
            {

                var checkPurchased = await _unitOfWork.purchaseRepository.CheckPurchaseCourse(_contextAccessor.GetId(), request.CourseId);

                if(checkPurchased is false)
                {
                    errors.Add(new CantFeedbackError());

                    return new MutationPayload<CreateFeedbackRequest, CreateFeedbackError>
                    {
                        errors = errors
                    };
                }

                var feedback = _mapper.Map<FeedbackEntity>(request);

                await _unitOfWork.feedbackRepository.AddOneAsync(feedback);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                var currentAvegrate = await _unitOfWork.feedbackRepository.TotalRate(request.CourseId);

                var course = await _unitOfWork.courseRepository.FindOneAsync(request.CourseId);

                if(currentAvegrate is null)
                {
                    return new MutationPayload<CreateFeedbackRequest, CreateFeedbackError>
                    {
                        payload = request,
                    };
                }

                float newAvegrate = (currentAvegrate.TotalRate + request.Rate) / (currentAvegrate.TotalFeedback + 1);

                course!.Rating=(float) Math.Round(newAvegrate,1);

                _unitOfWork.courseRepository.UpdateOne(course);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                await trans.CommitAsync(cancellationToken);

                return new MutationPayload<CreateFeedbackRequest, CreateFeedbackError>
                {
                    payload=request,
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
