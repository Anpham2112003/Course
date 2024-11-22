using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs;

namespace Application.MediaR.Comands.Account
{
    public class GoogleLoginRequest:IRequest<LoginResponse>
    {
        public string? Name{get;set;}
        public string? Email{get;set;}
    }
}
