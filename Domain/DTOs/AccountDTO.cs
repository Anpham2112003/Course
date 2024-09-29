using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs
{
    
    public class AccountDTO
    {
        
        public string? FirstName { get; set; }
        public string ? LastName { get; set; }
        public string? Email { get; set; }
        public string? PassWord { get; set; }

        
    }
}
