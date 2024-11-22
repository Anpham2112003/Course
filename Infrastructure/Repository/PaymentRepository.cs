using Domain.Entities;
using Infrastructure.DB.SQLDbContext;
using Infrastructure.Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class PaymentRepository : AbstractRepository<PaymentEntity, ApplicationDBContext>, IPaymentRepository<PaymentEntity>
    {
        public PaymentRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}
