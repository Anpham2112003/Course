using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Untils
{
    public sealed class MutationPayload<TReult, TError> where TReult : class
    {
        public TReult? payload { get; set; }

        public List<TError> errors { get; set; } = new List<TError>();
    }
}
