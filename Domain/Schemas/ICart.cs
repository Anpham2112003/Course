﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Schemas
{
    [UnionType]
    public interface ICart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CouresId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
