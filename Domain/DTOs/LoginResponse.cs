using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class LoginResponse
    {
        public Guid Id { get; set; }
        public string? Accesstoken {  get; set; }
        public string? Refreshtoken { get; set; }
    }
}
