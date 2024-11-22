
using Domain.Types.ErrorTypes.Erros.Topic;
using Domain.Types.ErrorTypes.Unions.Topic;
using Domain.Untils;
using Infrastructure.Unit0fWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Topic
{
    public class DeleteTopicRequestHandler : IRequestHandler<DeleteTopicRequest, MutationPayload<DeleteTopicRequest, DeleteTopicError>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTopicRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MutationPayload<DeleteTopicRequest, DeleteTopicError>> Handle(DeleteTopicRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<DeleteTopicError>();

            try
            {
                var topic = await _unitOfWork.topicRepository.FindOneAsync(request.Id);

                if(topic is null)
                {
                    errors.Add(new TopicNotFoundError());

                    return new MutationPayload<DeleteTopicRequest, DeleteTopicError>
                    {
                        errors = errors
                    };
                }

                topic.IsDeleted = true;

                _unitOfWork.topicRepository.UpdateOne(topic);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<DeleteTopicRequest, DeleteTopicError>
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
