using System;

namespace MyApp.Core.Domain
{
    public abstract class Entity
    {
        private Guid _id;

        public Entity(Guid id)
        {
            _id = id;
        }

        public Guid Id => _id;

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (Object.ReferenceEquals(this, compareTo))
                return true;

            if (compareTo is null)
                return false;

            return this.Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (this.GetType().GetHashCode() * 907) + this.Id.GetHashCode();
        }

        public override string ToString()
        {
            return this.GetType().Name + " [Id=" + this.Id + "]";
        }
    }
}
