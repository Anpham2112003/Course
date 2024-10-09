using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Errors.UnionError
{

    public interface BaseUnionError
    {
        public string? code { get; set; }
        public string? message { get; set; }
    }
}
