using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatLess.Domain.Primitives
{
    public abstract class AggregateRoot : Entity
    {
        protected AggregateRoot(Guid Id) : base(Id)
        {
        }
    }
}
