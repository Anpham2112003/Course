using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.EntityBase
{
    public interface ISoftDeleted
    {
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }

    }
}
