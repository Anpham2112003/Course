
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
    public class UpdateTopicRequestHandler : IRequestHandler<UpdateTopicRequest, MutationPayload<UpdateTopicRequest, UpdateTopicError>>
    {private readonly IUnitOfWork _unitOfWork;

        public UpdateTopicRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MutationPayload<UpdateTopicRequest, UpdateTopicError>> Handle(UpdateTopicRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<UpdateTopicError>();

            try
            {
                var checkTopicName = await _unitOfWork.topicRepository.HasTopicName(request.Name!);

                if (checkTopicName)
                {
                    errors.Add(new TopicNameExistError());

                    return new MutationPayload<UpdateTopicRequest, UpdateTopicError>
                    {
                        errors = errors
                    };
                }

                var topic = await _unitOfWork.topicRepository.FindOneAsync(request.Id);

                if(topic is null)
                {
                    errors.Add(new TopicNotFoundError());

                    return new MutationPayload<UpdateTopicRequest, UpdateTopicError>
                    {
                        errors = errors
                    };
                }

                topic.Name = request.Name;

                _unitOfWork.topicRepository.UpdateOne(topic);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<UpdateTopicRequest, UpdateTopicError>
                {
                    errors = errors
                };
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
