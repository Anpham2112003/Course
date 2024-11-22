
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
    public class DeleteTagRequestHandler : IRequestHandler<DeleteTagRequest, MutationPayload<DeleteTagRequest, DeleteTagError>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTagRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MutationPayload<DeleteTagRequest, DeleteTagError>> Handle(DeleteTagRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<DeleteTagError>();

            try
            {
                var tag = await _unitOfWork.tagRepository.FindOneAsync(request.Id);

                if(tag is null)
                {
                    errors.Add(new TagNotFoundError());

                    return new MutationPayload<DeleteTagRequest, DeleteTagError>
                    {
                        errors = errors
                    };
                }

                tag.IsDeleted = true;

                _unitOfWork.tagRepository.UpdateOne(tag);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<DeleteTagRequest, DeleteTagError>
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
