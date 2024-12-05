using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Schemas
{
    [UnionType]
    public interface IUser
    {
        public Guid id { get; set; }
        public string? FullName { get; set; }
        public bool Gender { get; set; }
        public string? Avatar { get; set; }
        public bool IsLecturer { get; set; }
        public string? Information { get; set; }
        
    }
}
