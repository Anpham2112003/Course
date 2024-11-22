using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Schemas
{
    public interface ICourse
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string? Name { get; set; }
        public int Purchase { get; set; }
        public float Price { get; set; }
        public bool IsSale { get; set; }
        public int Sale { get; set; }
        public DateTime Expired { get; set; }
        public string? Description { get; set; }
        public float Rating { get; set; }
        public float Duration { get; set; }
        public string? Thumbnail { get; set; }
        public bool IsPublish { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
