using Application.MediaR.Pipeline;
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
    public class DeleteCartRequest:IRequest<MutationPayload<Guid,DeleteCartError>>,IRequireValidation
    {
        public Guid Id { get; set; }
    }
}
