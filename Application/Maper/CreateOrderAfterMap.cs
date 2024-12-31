using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.Maper
{
    public class CreateOrderAfterMap : IMappingAction<CartEntity, OrderDTO>
    {
        private readonly IHttpContextAccessor _accessor;

        public CreateOrderAfterMap(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public void Process(CartEntity source, OrderDTO destination, ResolutionContext context)
        {
            if (source.courseEntity!.IsSale)
            {
                var amount = destination.Amount - (source.courseEntity.Price / 100 * source.courseEntity.Sale);
                
                destination.Amount = amount;
                
                destination.Email=_accessor.HttpContext!.User.FindFirstValue(ClaimTypes.Email);
            }
        }
    }
}
