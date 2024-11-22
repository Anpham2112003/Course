using Domain.Entities;
using Domain.Types.ErrorTypes.Erros.Tag;
using Domain.Types.ErrorTypes.Unions.Tag;
using Domain.Untils;
using Infrastructure.Unit0fWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Tag
{
    public class CreateTagRequestHandler : IRequestHandler<CreateTagRequest, MutationPayload<CreateTagRequest, CreateTagError>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTagRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MutationPayload<CreateTagRequest, CreateTagError>> Handle(CreateTagRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<CreateTagError>();

            try
            {
                var checkTag = await _unitOfWork.tagRepository.HasTagName(request.Name!);

                if(checkTag)
                {  
                    errors.Add(new TagNameExistError());

                    return new MutationPayload<CreateTagRequest, CreateTagError>
                    {
                        errors = errors
                    };
      
                }

                var tag = new TagEntity
                {
                    Name = request.Name,
                };

                await _unitOfWork.tagRepository.AddOneAsync(tag);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<CreateTagRequest, CreateTagError>
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
