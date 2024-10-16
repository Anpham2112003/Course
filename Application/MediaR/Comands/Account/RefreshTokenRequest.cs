using Domain.DTOs;
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
    public class RefreshTokenRequest : IRequest<MutationPayload<LoginResponse, RefreshTokenError>>
    {
        public string? Refreshtoken { get; set; }

    }
}
