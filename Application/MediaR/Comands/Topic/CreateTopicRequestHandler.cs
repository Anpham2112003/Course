using Domain.Entities;
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
    public class CreateTopicRequestHandler : IRequestHandler<CreateTopicRequest, MutationPayload<CreateTopicRequest, CreateTopicError>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTopicRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MutationPayload<CreateTopicRequest, CreateTopicError>> Handle(CreateTopicRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<CreateTopicError>();

            try
            {
                var checkTopic = await _unitOfWork.topicRepository.HasTopicName(request.Name!);

                if(checkTopic)
                {
                    errors.Add(new TopicNameExistError());

                    return new MutationPayload<CreateTopicRequest, CreateTopicError>
                    {
                        errors = errors,
                    };
                }

                var topic = new TopicEntity
                {

                    Name = request.Name,
                };

                await _unitOfWork.topicRepository.AddOneAsync(topic);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<CreateTopicRequest, CreateTopicError>
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
