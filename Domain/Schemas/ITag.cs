﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Schemas
{
    [UnionType]
    public interface ITag
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
