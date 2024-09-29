using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Response
{
    public sealed class Response<T> : IResponse<T>
    {
        public bool IsSuccess {get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Payload { get; set; }
    }
}
