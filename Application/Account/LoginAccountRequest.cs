using Domain.DTOs;
using Domain.Errors.UnionError.AccountUnion;
using Domain.Untils;
using HotChocolate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account
{
    public class LoginAccountRequest:IRequest<MutationPayload<LoginResponse,LoginAccountError>>
    {
       
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
