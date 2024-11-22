using Application.MediaR.Comands.CategoryLesson;
using Domain.Types.ErrorTypes.Unions.CategoryLesson;
using Domain.Untils;
using HotChocolate;
using HotChocolate.Types;
using MediatR;

namespace Api.Schemas.Mutation
{

    [ExtendObjectType(typeof(Mutations))]
    public class CategoryLessonMutation
    {
        public async Task<MutationPayload<CreateCategoryLessonRequest, CreateCategoryLessonError>> createCategoryLesson([Service] IMediator mediator,CreateCategoryLessonRequest input,CancellationToken cancellationToken)
        {
            var result = await mediator.Send(input, cancellationToken);

            return result;
        }

        public async Task<MutationPayload<UpdateCategoryLessonRequest, UpdateCategoryLessonError>> updateCategoryLesson([Service] IMediator mediator,UpdateCategoryLessonRequest input,CancellationToken cancellationToken)
        {
            var result = await mediator.Send(input, cancellationToken); 

            return result;
        }

        public async Task<MutationPayload<Guid,DeleteCategoryLessonError>> deleteCategoryLesson([Service] IMediator mediator,DeleteCategoryLessonRequest input , CancellationToken cancellationToken)
        {
            var result = await mediator.Send(input,cancellationToken);

            return result;
        }
    }
}
