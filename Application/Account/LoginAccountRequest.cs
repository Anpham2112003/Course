using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account
{
    public class LoginAccountRequest:IRequest<LoginResponse>
    {
       
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
