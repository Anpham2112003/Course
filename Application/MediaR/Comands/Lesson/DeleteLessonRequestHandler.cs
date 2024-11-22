
using Domain.Types.ErrorTypes.Erros.Course;
using Domain.Types.ErrorTypes.Erros.Lesson;
using Domain.Types.ErrorTypes.Unions.Lesson;
using Domain.Untils;
using Infrastructure.Unit0fWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Lesson
{
    public class DeleteLessonRequestHandler : IRequestHandler<DeleteLessonRequest, MutationPayload<Guid, DeleteLessonError>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;

        public DeleteLessonRequestHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
        }

        public async Task<MutationPayload<Guid, DeleteLessonError>> Handle(DeleteLessonRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<DeleteLessonError>();

            try
            {
                var lesson = await _unitOfWork.lessonRepository.FindOneAsync(request.Id);

                if(lesson is null)
                {
                    errors.Add(new LessonNotFoundError());

                    return new MutationPayload<Guid, DeleteLessonError>
                    {
                        errors = errors
                    };
                }

                if(lesson.UserId.Equals(_contextAccessor.GetId()) is false)
                {
                    errors.Add(new UnAuthorError());

                    return new MutationPayload<Guid, DeleteLessonError>
                    {
                        errors = errors
                    };
                }

                lesson.IsDeleted = true;

                _unitOfWork.lessonRepository.UpdateOne(lesson);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<Guid, DeleteLessonError>
                {
                    payload = request.Id,
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
