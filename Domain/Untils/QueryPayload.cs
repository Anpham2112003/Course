using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Untils
{
    public sealed class QueryPayload<TResult,TError> 
    {
        public TResult? payload { get; set; }

        public List<TError> errors { get; set; } = new List<TError>();
    }
}
