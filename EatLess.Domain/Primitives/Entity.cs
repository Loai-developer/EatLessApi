﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatLess.Domain.Primitives
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        protected Entity(Guid id)
        {
            Id = id;
        }

        protected Entity() { }
    }
}
