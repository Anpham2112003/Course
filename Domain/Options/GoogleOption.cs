using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Options
{
    public class GoogleOption
    {
        public const string Google = "Authentication:Google";
        public string? Client_id { get; set; }
        public string? Client_secret { get; set; }
        public string? Callback_path { get; set; }
        
        public string? Redirect_path { get; set; }
    }
}
