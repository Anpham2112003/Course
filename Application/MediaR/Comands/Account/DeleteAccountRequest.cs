﻿using Domain.Types.ErrorTypes.BaseError.AccountUnion;
using Domain.Untils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Account
{
    public class DeleteAccountRequest : IRequest<MutationPayload<string, DeleteAccountError>>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
