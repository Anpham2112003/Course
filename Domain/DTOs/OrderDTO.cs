using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }   
        public string? Email { get; set; }
        public Guid CourseId { get; set; }
        public string? Name { get; set; }    
        public float Amount {  get; set; }
        public string? Currency { get; set; } = "vnd";
        public string? Thumbnail {  get; set; }
       
    }
}
