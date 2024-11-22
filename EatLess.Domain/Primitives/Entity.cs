using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatLess.Domain.Primitives
{
    public abstract class Entity : IEquatable<Entity>
    {
        //init is used here because we cannot change this id through the lifetime of the entity existence
        //init helps to set the value once the object is initialized.
        //making it private so it can only be set from inside the class
        public Guid Id { get; private init; }
        protected Entity(Guid id)
        {
            Id = id;
        }
        protected Entity() { }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;
            if (obj.GetType() != GetType())
                return false;
            if(obj is not Entity entity)
                return false;
            return entity.Id == Id;
        }

        public bool Equals(Entity? other)
        {
            if (other is null)
                return false;
            if (other.GetType() != GetType())
                return false;
            return other.Id == Id;
        }
    }
}
