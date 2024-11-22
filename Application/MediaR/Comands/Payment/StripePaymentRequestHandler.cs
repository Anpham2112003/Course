using AutoMapper;
using Domain.DTOs;
using Domain.Interfaces.Payment;
using Domain.Types.ErrorTypes.Erros.Cart;
using Domain.Types.ErrorTypes.Erros.Course;
using Domain.Types.ErrorTypes.Unions.Payment;
using Domain.Untils;
using Infrastructure.Unit0fWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Payment
{
    public class StripePaymentRequestHandler : IRequestHandler<StripePaymentRequest, MutationPayload<Session, PaymentError>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStripService _stripService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;
        public StripePaymentRequestHandler(IStripService stripService, IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _stripService = stripService;
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<MutationPayload<Session, PaymentError>> Handle(StripePaymentRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<PaymentError>();

            try
            {
                var userId = _contextAccessor.GetId();

                var cart = await _unitOfWork.cartRepository.GetCartDetailAsync(request.CartId);

                if(cart is null)
                {
                    errors.Add(new CartNotFoundError());

                    return new MutationPayload<Session, PaymentError>
                    {
                        errors = errors,
                    };
                }

                if(cart.UserId.Equals(userId) is false)
                {
                    errors.Add(new OwnerError());

                    return new MutationPayload<Session, PaymentError>
                    {
                        errors = errors
                    };
                }

                if(cart.courseEntity is null)
                {
                    errors.Add(new CourseNotFoundError
                    {
                        message = "Course may be delete!"
                    });

                    return new MutationPayload<Session, PaymentError>
                    {
                        errors = errors
                    };
                }

                var order = _mapper.Map<OrderDTO>(cart);

                var session = await _stripService.CreateSesssion(order);

                return new MutationPayload<Session, PaymentError>
                {
                    payload = session,
                };

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
