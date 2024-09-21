using Domain.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CartEntity : BaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CouresId { get; set; }

        ////////////////////////////////////
        public UserEntity? userEntity { get; set; }
        public CourseEntity? courseEntity { get; set; }
    }
}
