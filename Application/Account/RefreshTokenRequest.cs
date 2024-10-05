using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account
{
    public class RefreshTokenRequest:IRequest<LoginResponse>
    {
        public string? Refreshtoken {  get; set; }

    }
}
