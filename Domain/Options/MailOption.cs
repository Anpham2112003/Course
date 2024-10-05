using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Options
{
    public class MailOption
    {
        public const string Mail = "Mail";
        public string? Host {  get; set; }
        public int Port { get; set; }
        public string? Account {  get; set; }
        public string? Password {  get; set; }
    }
}
