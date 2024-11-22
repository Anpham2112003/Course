using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Maper
{
    public class CreateOrderAfterMap : IMappingAction<CartEntity, OrderDTO>
    {
        public void Process(CartEntity source, OrderDTO destination, ResolutionContext context)
        {
            if (source.courseEntity!.IsSale)
            {
                var amount = destination.Amount - (source.courseEntity.Price / 100 * source.courseEntity.Sale);

                destination.Amount = amount;
            }
        }
    }
}
