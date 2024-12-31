using AutoMapper;
using Domain.Entities;
using Infrastructure.DB.SQLDbContext;
using Infrastructure.Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class PaymentRepository : AbstractRepository<PaymentEntity, ApplicationDBContext>, IPaymentRepository<PaymentEntity>
    {
        public PaymentRepository(ApplicationDBContext dBContext, IMapper mapper) : base(dBContext, mapper)
        {
        }

        public IQueryable<TPayment> GetPaymentByUserId<TPayment>(Guid userId)
        {
            return this.dBContext.Set<PaymentEntity>()
                .Where(x=>x.UserId == userId)
                .AsNoTracking()
                .ProjectTo<TPayment>(_mapper.ConfigurationProvider);
        }
    }
}
