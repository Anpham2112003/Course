using Domain.Types.ErrorTypes.Unions.Cart;
using Domain.Untils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Cart
{
    public class CreateCartRequest:IRequest<MutationPayload<CreateCartRequest,CreateCartError>>
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
    }
}
