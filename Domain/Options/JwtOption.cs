using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Options
{
    public sealed class JwtOption
    {
        public const string Jwt = "Jwt";
        public string? Issuer {  get; set; }
        public string? Audience {  get; set; }
        public string? Accesskey {  get; set; }
        public string? Refreshkey {  get; set; }
        public int AccesskeyExprire {  get; set; }
        public int RefreshkeyExpire { get; set; }

    }
}
