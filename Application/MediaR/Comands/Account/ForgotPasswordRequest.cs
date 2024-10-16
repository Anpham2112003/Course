using Domain.Types.ErrorTypes.BaseError.AccountUnion;
using Domain.Untils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Account
{
    public class ForgotPasswordRequest : IRequest<MutationPayload<string, ForgetPassowordError>>
    {
        public string? Email { get; set; }

    }
}
