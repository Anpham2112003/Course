using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Schemas
{
    public interface IPayment
    {
        public Guid Id { get; set; }
    }
}
