﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.EntityBase
{
    public interface BaseEntity<T>:IEntity
    {
        public T Id { get; set; }
    }
}
