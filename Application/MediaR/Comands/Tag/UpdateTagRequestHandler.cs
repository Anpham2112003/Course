
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
    public class UpdateTagRequestHandler : IRequestHandler<UpdateTagRequest, MutationPayload<UpdateTagRequest, UpdateTagError>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTagRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MutationPayload<UpdateTagRequest, UpdateTagError>> Handle(UpdateTagRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<UpdateTagError>();

            try
            {
                var tag = await _unitOfWork.tagRepository.FindTagByIdOrNameAsync(request.Id, request.Name!);

                if(tag is null)
                {
                    errors.Add(new TagNotFoundError());

                    return new MutationPayload<UpdateTagRequest, UpdateTagError>
                    {
                        errors = errors
                    };

                    
                }

                var checkExist = await _unitOfWork.tagRepository.HasTagName(request.Name!);

                if (checkExist)
                {
                    errors.Add(new TagNameExistError());

                    return new MutationPayload<UpdateTagRequest, UpdateTagError>
                    {
                        errors = errors
                    };
                }

                tag.Name = request.Name;

                _unitOfWork.tagRepository.UpdateOne(tag);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<UpdateTagRequest, UpdateTagError>
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
