using Domain.Entities;
using Domain.Types.ErrorTypes.Erros.Course;
using Domain.Types.ErrorTypes.Erros.Purchase;
using Domain.Types.ErrorTypes.Unions.Cart;
using Domain.Untils;
using Infrastructure.Unit0fWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Cart
{
    public class CreateCartRequestHandler : IRequestHandler<CreateCartRequest, MutationPayload<CreateCartRequest, CreateCartError>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;

        public CreateCartRequestHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
        }

        public async Task<MutationPayload<CreateCartRequest, CreateCartError>> Handle(CreateCartRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<CreateCartError>();

            try
            {
                var userId = _contextAccessor.GetId();

                var checkCourse = await _unitOfWork.courseRepository.HasCourse(request.CourseId);

                if(checkCourse is false)
                {
                    errors.Add(new CourseNotFoundError());

                    return new MutationPayload<CreateCartRequest, CreateCartError>
                    {
                        errors = errors
                    };
                }

                var checkPurchsed = await _unitOfWork.purchaseRepository.CheckPurchaseCourse(userId, request.CourseId);

                if (checkPurchsed)
                {
                    errors.Add(new PurchasedError());

                    return new MutationPayload<CreateCartRequest, CreateCartError>
                    {
                        errors = errors
                    };
                }



                var cart = new CartEntity
                {
                    Id = request.Id,
                    CouresId = request.CourseId,
                    UserId = userId,
                };

                await _unitOfWork.cartRepository.AddOneAsync(cart);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<CreateCartRequest, CreateCartError>
                {
                    payload = request,
                };

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
