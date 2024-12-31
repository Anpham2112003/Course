using Api.DataLoader;
using Domain.Schemas;
using HotChocolate;
using Infrastructure.Unit0fWork;
using HotChocolate.Types;
using HotChocolate.Data;

namespace Api.Schemas.Query
{
    public class PrivateUser : IUser
    {
        public Guid id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public bool Gender { get; set; }
        public string? Avatar { get; set; }
        public bool IsLecturer { get; set; }
        public string? Information { get; set; }
        public DateTime UpdatedAt { get; set; }

      

    }
}
